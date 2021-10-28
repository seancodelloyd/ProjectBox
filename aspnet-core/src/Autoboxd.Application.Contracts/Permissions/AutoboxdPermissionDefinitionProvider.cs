using Autoboxd.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Autoboxd.Permissions
{
    public class AutoboxdPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AutoboxdPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AutoboxdPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AutoboxdResource>(name);
        }
    }
}
