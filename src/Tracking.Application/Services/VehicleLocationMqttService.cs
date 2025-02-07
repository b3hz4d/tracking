using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;
using Orleans;
using Tracking.Grains;
using Tracking.ValueObejcts;
using Volo.Abp.DependencyInjection;

namespace Tracking.Services
{
    public class VehicleLocationMqttService : BackgroundService, ITransientDependency
    {
        private readonly ILogger<VehicleLocationMqttService> _logger;
        private readonly IGrainFactory _grainFactory;
        private IMqttClient _mqttClient;

        public VehicleLocationMqttService(
            ILogger<VehicleLocationMqttService> logger,
            IGrainFactory grainFactory)
        {
            _logger = logger;
            _grainFactory = grainFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mqttFactory = new MqttFactory();
            _mqttClient = mqttFactory.CreateMqttClient();

            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("192.168.3.103", 1883) // Configure your MQTT broker address and port
                .WithTlsOptions(e => e.UseTls(false))
                .Build();

            _mqttClient.ApplicationMessageReceivedAsync += HandleMessageAsync;

            await _mqttClient.ConnectAsync(mqttClientOptions, stoppingToken);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f => f.WithTopic("Vehicles/+/location"))
                .Build();

            await _mqttClient.SubscribeAsync(mqttSubscribeOptions, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                if (!_mqttClient.IsConnected)
                {
                    try
                    {
                        await _mqttClient.ConnectAsync(mqttClientOptions, stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to reconnect to MQTT broker");
                        await Task.Delay(5000, stoppingToken); // Wait 5 seconds before retrying
                    }
                }
                await Task.Delay(1000, stoppingToken); // Check connection every second
            }
        }

        private async Task HandleMessageAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                var topic = e.ApplicationMessage.Topic;
                var vehicleId = ExtractVehicleIdFromTopic(topic);
                var payload = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);
                
                var location = JsonSerializer.Deserialize<Location>(payload);
                if (location != null)
                {
                    var vehicleGrain = _grainFactory.GetGrain<IVehicleGrain>(vehicleId);
                    await vehicleGrain.UpdateLocationAsync(location);
                    _logger.LogInformation("Updated location for vehicle {VehicleId}", vehicleId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing MQTT message");
            }
        }

        private Guid ExtractVehicleIdFromTopic(string topic)
        {
            // Topic format: Vehicles/{vehicleId}/location
            var parts = topic.Split('/');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid topic format", nameof(topic));
            }

            if (!Guid.TryParse(parts[1], out var vehicleId))
            {
                throw new ArgumentException("Invalid vehicle ID in topic", nameof(topic));
            }

            return vehicleId;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_mqttClient != null)
            {
                await _mqttClient.DisconnectAsync(new MqttClientDisconnectOptions(), cancellationToken);
                _mqttClient.Dispose();
            }

            await base.StopAsync(cancellationToken);
        }
    }
} 