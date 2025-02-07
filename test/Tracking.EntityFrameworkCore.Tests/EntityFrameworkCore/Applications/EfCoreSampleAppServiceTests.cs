using Tracking.Samples;
using Xunit;

namespace Tracking.EntityFrameworkCore.Applications;

[Collection(TrackingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TrackingEntityFrameworkCoreTestModule>
{

}
