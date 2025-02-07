using Volo.Abp.Settings;

namespace Tracking.Settings;

public class TrackingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TrackingSettings.MySetting1));
    }
}
