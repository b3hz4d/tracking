using Tracking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Tracking.Permissions;

public class TrackingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var trackingGroup = context.AddGroup(TrackingPermissions.GroupName);

        var vehiclePermission = trackingGroup.AddPermission(TrackingPermissions.Vehicle.Default);
        vehiclePermission.AddChild(TrackingPermissions.Vehicle.Create);
        vehiclePermission.AddChild(TrackingPermissions.Vehicle.Update);
        vehiclePermission.AddChild(TrackingPermissions.Vehicle.Delete);
        vehiclePermission.AddChild(TrackingPermissions.Vehicle.Read);

        var personPermission = trackingGroup.AddPermission(TrackingPermissions.Person.Default);
        personPermission.AddChild(TrackingPermissions.Person.Create);
        personPermission.AddChild(TrackingPermissions.Person.Update);
        personPermission.AddChild(TrackingPermissions.Person.Delete);
        personPermission.AddChild(TrackingPermissions.Person.Read);

        var productPermission = trackingGroup.AddPermission(TrackingPermissions.Product.Default);
        productPermission.AddChild(TrackingPermissions.Product.Create);
        productPermission.AddChild(TrackingPermissions.Product.Update);
        productPermission.AddChild(TrackingPermissions.Product.Delete);
        productPermission.AddChild(TrackingPermissions.Product.Read);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TrackingResource>(name);
    }
}
