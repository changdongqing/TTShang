using System.Threading.Tasks;
using TTShang.Localization;
using TTShang.MultiTenancy;
using Volo.Abp.UI.Navigation;
using TTShang.TenantManagement.Blazor;
using TTShang.IdentityManagement.Blazor;
using TTShang.SettingManagement.Blazor;
using AntDesign;

namespace TTShang.Blazor.Menus;

public class TTShangMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<TTShangResource>();
        
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                TTShangMenus.Home,
                l["Menu:Home"],
                "/",
                icon: IconType.Outline.Home,
                order: 1
            )
        );

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;
    
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
