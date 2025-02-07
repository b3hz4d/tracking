using Volo.Abp.Modularity;

namespace Tracking;

/* Inherit from this class for your domain layer tests. */
public abstract class TrackingDomainTestBase<TStartupModule> : TrackingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
