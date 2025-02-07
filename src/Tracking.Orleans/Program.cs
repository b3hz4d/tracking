using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Tracking.Grains;
using Tracking.Services;
using Volo.Abp;
using Tracking;
using Volo.Abp.Modularity;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder
            .UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "tracking-service";
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .UseDashboard(options => { })
            .ConfigureServices(services =>
            {
                // Configure ABP before grain activation
                services.AddApplication<TrackingOrleansModule>();
            });
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<VehicleLocationMqttService>();
    })
    .UseAutofac() // Use Autofac as the DI container
    .RunConsoleAsync(); 