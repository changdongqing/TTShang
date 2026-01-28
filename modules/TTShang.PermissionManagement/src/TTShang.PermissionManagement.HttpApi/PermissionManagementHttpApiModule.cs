using Localization.Resources.AbpUi;
using TTShang.PermissionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TTShang.PermissionManagement;

[DependsOn(
    typeof(PermissionManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PermissionManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PermissionManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PermissionManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
