using TTShang.AccountManagement.Blazor;
using TTShang.AntDesignTheme.Blazor.Server;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Modularity;

namespace TTShang.AccountManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAccountBlazorAntDesignModule),
    typeof(AbpIdentityAspNetCoreModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpAccountBlazorServerAntDesignModule : AbpModule
{
}
