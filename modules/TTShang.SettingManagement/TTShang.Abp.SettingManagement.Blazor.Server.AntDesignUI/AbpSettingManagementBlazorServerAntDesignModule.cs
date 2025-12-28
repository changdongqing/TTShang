using TTShang.Abp.AspnetCore.Components.Server.AntDesignTheme;
using Volo.Abp.Modularity;
using TTShang.Abp.SettingManagement.Blazor.AntDesignUI;

namespace TTShang.Abp.SettingManagement.Blazor.Server.AntDesignUI;

[DependsOn(
    typeof(AbpSettingManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpSettingManagementBlazorServerAntDesignModule : AbpModule
{
    
}
