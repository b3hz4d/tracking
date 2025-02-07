using Tracking.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Tracking.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TrackingEntityFrameworkCoreModule),
    typeof(TrackingApplicationContractsModule)
    )]
public class TrackingDbMigratorModule : AbpModule
{
}
