using Microsoft.Extensions.Localization;
using Tracking.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Tracking.Web;

[Dependency(ReplaceServices = true)]
public class TrackingBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TrackingResource> _localizer;

    public TrackingBrandingProvider(IStringLocalizer<TrackingResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
