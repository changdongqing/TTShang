using Localization.Resources.AbpUi;
using TTShang.FeatureManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(FeatureManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class FeatureManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(FeatureManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FeatureManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
