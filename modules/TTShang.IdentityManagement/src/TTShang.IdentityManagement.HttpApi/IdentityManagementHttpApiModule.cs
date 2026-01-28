using Localization.Resources.AbpUi;
using TTShang.IdentityManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class IdentityManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(IdentityManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<IdentityManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
