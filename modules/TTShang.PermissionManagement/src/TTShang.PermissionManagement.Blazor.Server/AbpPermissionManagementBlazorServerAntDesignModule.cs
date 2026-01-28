using TTShang.AntDesignTheme.Blazor.Server;
using TTShang.PermissionManagement.Blazor;
using Volo.Abp.Modularity;

namespace TTShang.PermissionManagement.Blazor.Server;

[DependsOn(
    typeof(AbpPermissionManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpPermissionManagementBlazorServerAntDesignModule : AbpModule
{
}
