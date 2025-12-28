using TTShang.Abp.AspnetCore.Components.WebAssembly.AntDesignTheme;
using TTShang.Abp.PermissionManagement.Blazor.AntDesignUI;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace TTShang.Abp.PermissionManagement.Blazor.WebAssembly.AntDesignUI;

[DependsOn(
    typeof(AbpPermissionManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyAntDesignThemeModule),
    typeof(AbpPermissionManagementHttpApiClientModule)
)]
public class AbpPermissionManagementBlazorWebAssemblyAntDesignModule : AbpModule
{
}
