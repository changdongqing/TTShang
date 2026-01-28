using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace TTShang.AntDesignTheme.Blazor.Menus;

public class AntDesignThemeMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(AntDesignThemeMenus.Prefix, displayName: "AntDesignTheme", "/AntDesignTheme", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
