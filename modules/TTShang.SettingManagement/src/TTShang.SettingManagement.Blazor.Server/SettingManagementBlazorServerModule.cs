using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TTShang.SettingManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(SettingManagementBlazorModule)
    )]
public class SettingManagementBlazorServerModule : AbpModule
{

}
