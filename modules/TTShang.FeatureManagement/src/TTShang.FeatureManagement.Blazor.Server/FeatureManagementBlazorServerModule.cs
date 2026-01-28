using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(FeatureManagementBlazorModule)
    )]
public class FeatureManagementBlazorServerModule : AbpModule
{

}
