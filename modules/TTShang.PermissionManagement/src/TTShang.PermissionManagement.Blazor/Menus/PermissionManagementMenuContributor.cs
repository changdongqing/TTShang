using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace TTShang.PermissionManagement.Blazor.Menus;

public class PermissionManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(PermissionManagementMenus.Prefix, displayName: "PermissionManagement", "/PermissionManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
