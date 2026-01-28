using Localization.Resources.AbpUi;
using TTShang.SettingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TTShang.SettingManagement;

[DependsOn(
    typeof(SettingManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SettingManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SettingManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SettingManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
