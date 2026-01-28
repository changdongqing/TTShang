using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TTShang.TenantManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(TenantManagementBlazorModule)
    )]
public class TenantManagementBlazorServerModule : AbpModule
{

}
