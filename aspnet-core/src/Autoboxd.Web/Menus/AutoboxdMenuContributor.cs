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

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            context.Menu.AddItem(new ApplicationMenuItem(
                "Autoboxd.Items",
                l["Menu:Cars"],
                url: "/Cars/All"
            ));

            context.Menu.AddItem(new ApplicationMenuItem(
                "Autoboxd.Lists",
                l["Menu:Lists"],
                url: "/Lists/All"
            ));

            context.Menu.AddItem(new ApplicationMenuItem(
                "Autoboxd.Articles",
                l["Menu:Articles"],
                url: "/Articles/All"
            ));

            context.Menu.AddItem(new ApplicationMenuItem(
                "Autoboxd.Reviews",
                l["Menu:Reviews"],
                url: "/Reviews/All"
            ));

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
