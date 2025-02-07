using System;
using System.Collections.Generic;
using System.Text;
using Tracking.Localization;
using Volo.Abp.Application.Services;

namespace Tracking;

/* Inherit your application services from this class.
 */
public abstract class TrackingAppService : ApplicationService
{
    protected TrackingAppService()
    {
        LocalizationResource = typeof(TrackingResource);
    }
}
