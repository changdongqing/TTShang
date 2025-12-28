using TTShang.Abp.AspnetCore.Components.WebAssembly.AntDesignTheme;
using Volo.Abp.Modularity;
using TTShang.Abp.SettingManagement.Blazor.AntDesignUI;
using Volo.Abp.SettingManagement;

namespace TTShang.Abp.SettingManagement.Blazor.WebAssembly.AntDesignUI;

[DependsOn(
    typeof(AbpSettingManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyAntDesignThemeModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class AbpSettingManagementBlazorWebAssemblyAntDesignModule : AbpModule
{
    
}
