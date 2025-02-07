using Xunit;

namespace Tracking.EntityFrameworkCore;

[CollectionDefinition(TrackingTestConsts.CollectionDefinitionName)]
public class TrackingEntityFrameworkCoreCollection : ICollectionFixture<TrackingEntityFrameworkCoreFixture>
{

}
