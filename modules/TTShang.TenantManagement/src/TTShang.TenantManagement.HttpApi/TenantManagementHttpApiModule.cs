using Localization.Resources.AbpUi;
using TTShang.TenantManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TTShang.TenantManagement;

[DependsOn(
    typeof(TenantManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class TenantManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TenantManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TenantManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
