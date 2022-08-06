using Listform_Manager.Localization;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Listform_Manager.Menus;

public class Listform_ManagerMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<Listform_ManagerResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                Listform_ManagerMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                Listform_ManagerMenus.List,
                l["Menu:Lists"],
                icon: "fas fa-list"
            ).AddItem(
                new ApplicationMenuItem(
                    Listform_ManagerMenus.Product,
                    l["Menu:Lists:Products"],
                    "/List/1",
                    icon: "fas fa-list",
                    order: 0,
                    requiredPermissionName: Permissions.Listform_ManagerPermissions.Product.Products
                )
            ).AddItem(
                new ApplicationMenuItem(
                    Listform_ManagerMenus.Formlist,
                    l["Menu:Lists:Formlist"],
                    "/List/2",
                    icon: "fas fa-list",
                    order: 0,
                    requiredPermissionName: Permissions.Listform_ManagerPermissions.Formlist.Formlists
                )
            )
        );

        if (Listform_ManagerModule.IsMultiTenant)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        return Task.CompletedTask;
    }
}
