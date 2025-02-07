using Tracking.Samples;
using Xunit;

namespace Tracking.EntityFrameworkCore.Domains;

[Collection(TrackingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TrackingEntityFrameworkCoreTestModule>
{

}
