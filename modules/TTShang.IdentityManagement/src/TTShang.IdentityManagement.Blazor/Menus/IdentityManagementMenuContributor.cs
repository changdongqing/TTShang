using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace TTShang.IdentityManagement.Blazor.Menus;

public class IdentityManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(IdentityManagementMenus.Prefix, displayName: "IdentityManagement", "/IdentityManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
