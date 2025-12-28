using TTShang.Abp.AspnetCore.Components.WebAssembly.AntDesignTheme;
using TTShang.Abp.FeatureManagement.Blazor.AntDesignUI;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;

namespace TTShang.Abp.FeatureManagement.Blazor.WebAssembly.AntDesignUI;

[DependsOn(
    typeof(AbpFeatureManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyAntDesignThemeModule),
    typeof(AbpFeatureManagementHttpApiClientModule)
)]
public class AbpFeatureManagementBlazorWebAssemblyAntDesignModule : AbpModule
{
}
