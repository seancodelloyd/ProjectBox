using Autoboxd.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Autoboxd.Permissions
{
    public class AutoboxdPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var group = context.AddGroup(AutoboxdPermissions.GroupName);

            var booksPermission = group.AddPermission(AutoboxdPermissions.Items.Default, L("Permission:Items"));
            booksPermission.AddChild(AutoboxdPermissions.Items.Create, L("Permission:Items.Create"));
            booksPermission.AddChild(AutoboxdPermissions.Items.Edit, L("Permission:Items.Edit"));
            booksPermission.AddChild(AutoboxdPermissions.Items.Delete, L("Permission:Items.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AutoboxdResource>(name);
        }
    }
}
