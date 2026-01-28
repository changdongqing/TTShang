using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace TTShang.TenantManagement.Blazor.Menus;

public class TenantManagementMenuContributor : IMenuContributor
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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(TenantManagementMenus.Prefix, displayName: "TenantManagement", "/TenantManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
