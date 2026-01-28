using TTShang.AntDesignTheme.Blazor.Server;
using Volo.Abp.Modularity;
using TTShang.SettingManagement.Blazor;

namespace TTShang.SettingManagement.Blazor.Server;

[DependsOn(
    typeof(AbpSettingManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpSettingManagementBlazorServerAntDesignModule : AbpModule
{
    
}
