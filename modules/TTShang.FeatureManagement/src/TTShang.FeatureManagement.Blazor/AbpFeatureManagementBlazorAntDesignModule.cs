using TTShang.AntDesignTheme.Blazor;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement.Blazor;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebAntDesignThemeModule),
    typeof(AbpMapperlyModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpFeaturesModule)
)]
public class AbpFeatureManagementBlazorAntDesignModule : AbpModule
{

}
