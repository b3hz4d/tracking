using Tracking.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Tracking.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TrackingPageModel : AbpPageModel
{
    protected TrackingPageModel()
    {
        LocalizationResourceType = typeof(TrackingResource);
    }
}
