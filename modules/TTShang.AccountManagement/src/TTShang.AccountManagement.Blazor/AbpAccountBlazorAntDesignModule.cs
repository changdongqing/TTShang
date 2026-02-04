using TTShang.AntDesignTheme.Blazor;
using TTShang.AntDesignTheme.Blazor.Routing;
using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace TTShang.AccountManagement.Blazor;

[DependsOn(
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebAntDesignThemeModule)
)]
public class AbpAccountBlazorAntDesignModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(AbpAccountBlazorAntDesignModule).Assembly);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AccountMenuContributor());
        });
    }
}
