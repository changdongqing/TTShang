using TTShang.AntDesignTheme.Blazor;
using TTShang.AntDesignTheme.Blazor.Routing;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using TTShang.SettingManagement.Blazor.Settings;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Blazor;
using Volo.Abp.UI.Navigation;

namespace TTShang.SettingManagement.Blazor;

[DependsOn(
    typeof(AbpMapperlyModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebAntDesignThemeModule)
)]
public class AbpSettingManagementBlazorAntDesignModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMapperlyObjectMapper<AbpSettingManagementBlazorAntDesignModule>();

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new SettingManagementMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(AbpSettingManagementBlazorAntDesignModule).Assembly);
        });

        Configure<SettingManagementComponentOptions>(options =>
        {
            options.Contributors.Add(new AntDesignSettingDefultPageContributor());
            options.Contributors.Add(new AntDesignTimeZonePageContributor());
        });
    }
}
