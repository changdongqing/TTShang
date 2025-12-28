using TTShang.Abp.AspnetCore.Components.Server.AntDesignTheme;
using TTShang.Abp.FeatureManagement.Blazor.AntDesignUI;
using Volo.Abp.Modularity;

namespace TTShang.Abp.FeatureManagement.Blazor.Server.AntDesignUI;

[DependsOn(
    typeof(AbpFeatureManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpFeatureManagementBlazorServerAntDesignModule : AbpModule
{
}
