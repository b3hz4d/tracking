using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Orleans.Configuration;
using Orleans.Hosting;
using Tracking.Grains;
using Tracking.Services;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder
            .UseLocalhostClustering()
            .UseDashboard(options => { });
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<VehicleLocationMqttService>();
    })
    .RunConsoleAsync(); 