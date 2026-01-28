using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TTShang.PermissionManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(PermissionManagementBlazorModule)
    )]
public class PermissionManagementBlazorServerModule : AbpModule
{

}
