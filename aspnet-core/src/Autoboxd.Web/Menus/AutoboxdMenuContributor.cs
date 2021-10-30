using System.Threading.Tasks;
using Autoboxd.Localization;
using Autoboxd.MultiTenancy;
using Autoboxd.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Autoboxd.Web.Menus
{
    public class AutoboxdMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<AutoboxdResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    AutoboxdMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

            if (await context.IsGrantedAsync(AutoboxdPermissions.Items.Default))
            {
                administration.AddItem(
                    new ApplicationMenuItem(
                        "ItemStore.Items",
                        l["Menu:Items"],
                        url: "/Items"
                    )
                );
            }
        }
    }
}
