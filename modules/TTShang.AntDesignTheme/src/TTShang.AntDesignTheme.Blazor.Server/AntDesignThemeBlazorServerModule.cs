using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(AntDesignThemeBlazorModule)
    )]
public class AntDesignThemeBlazorServerModule : AbpModule
{

}
