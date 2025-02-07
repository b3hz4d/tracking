using Tracking.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Tracking.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TrackingController : AbpControllerBase
{
    protected TrackingController()
    {
        LocalizationResource = typeof(TrackingResource);
    }
}
