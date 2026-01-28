using TTShang.AntDesignTheme.Blazor.Routing;
using TTShang.FeatureManagement.Blazor;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation;

namespace TTShang.TenantManagement.Blazor;


[DependsOn(
    typeof(AbpMapperlyModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpFeatureManagementBlazorAntDesignModule)
)]
public class AbpTenantManagementBlazorAntDesignModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMapperlyObjectMapper<AbpTenantManagementBlazorAntDesignModule>();

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new TenantManagementBlazorMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(AbpTenantManagementBlazorAntDesignModule).Assembly);
        });
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper
                .ApplyEntityConfigurationToUi(
                    TenantManagementModuleExtensionConsts.ModuleName,
                    TenantManagementModuleExtensionConsts.EntityNames.Tenant,
                    createFormTypes: new[] { typeof(TenantCreateDto) },
                    editFormTypes: new[] { typeof(TenantUpdateDto) }
                );
        });
    }
}
