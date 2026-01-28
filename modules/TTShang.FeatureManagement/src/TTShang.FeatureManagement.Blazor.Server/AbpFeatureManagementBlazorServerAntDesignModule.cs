using TTShang.AntDesignTheme.Blazor.Server;
using TTShang.FeatureManagement.Blazor;
using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement.Blazor.Server;

[DependsOn(
    typeof(AbpFeatureManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpFeatureManagementBlazorServerAntDesignModule : AbpModule
{
}
