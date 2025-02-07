using Volo.Abp.Modularity;

namespace Tracking;

[DependsOn(
    typeof(TrackingDomainModule),
    typeof(TrackingTestBaseModule)
)]
public class TrackingDomainTestModule : AbpModule
{

}
