using Localization.Resources.AbpUi;
using TTShang.AntDesignTheme.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AntDesignThemeApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AntDesignThemeHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AntDesignThemeHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AntDesignThemeResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
