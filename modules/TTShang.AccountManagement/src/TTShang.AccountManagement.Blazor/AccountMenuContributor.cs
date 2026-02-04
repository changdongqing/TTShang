using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace TTShang.AccountManagement.Blazor;

/// <summary>
/// Contributes account-related items to the user menu
/// </summary>
public class AccountMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        var localizer = context.ServiceProvider.GetRequiredService<IStringLocalizer<AccountResource>>();

        if (currentUser.IsAuthenticated)
        {
            // Add logout menu item
            context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Logout",
                localizer["Logout"],
                url: "account/logout",
                icon: "fa fa-sign-out-alt",
                order: 10000 // Put it at the end
            ));
        }
    }
}
