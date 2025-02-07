using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Tracking.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Data;

namespace Tracking;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TrackingApplicationModule),
    typeof(TrackingEntityFrameworkCoreModule)
)]
public class TrackingOrleansModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var connectionString = configuration.GetConnectionString("Default");

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });

        context.Services.AddAbpDbContext<TrackingDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
} 