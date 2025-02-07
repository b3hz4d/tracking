using Volo.Abp.Modularity;

namespace Tracking;

public abstract class TrackingApplicationTestBase<TStartupModule> : TrackingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
