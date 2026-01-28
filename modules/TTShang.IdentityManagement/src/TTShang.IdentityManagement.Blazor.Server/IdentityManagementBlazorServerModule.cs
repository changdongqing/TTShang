using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(IdentityManagementBlazorModule)
    )]
public class IdentityManagementBlazorServerModule : AbpModule
{

}
