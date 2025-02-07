using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Tracking.Pages;

public class Index_Tests : TrackingWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
