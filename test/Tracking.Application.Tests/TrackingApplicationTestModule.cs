using Volo.Abp.Modularity;

namespace Tracking;

[DependsOn(
    typeof(TrackingApplicationModule),
    typeof(TrackingDomainTestModule)
)]
public class TrackingApplicationTestModule : AbpModule
{

}
