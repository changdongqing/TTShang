using TTShang.Abp.AspnetCore.Components.Server.AntDesignTheme;
using TTShang.Abp.PermissionManagement.Blazor.AntDesignUI;
using Volo.Abp.Modularity;

namespace TTShang.Abp.PermissionManagement.Blazor.Server.AntDesignUI;

[DependsOn(
    typeof(AbpPermissionManagementBlazorAntDesignModule),
    typeof(AbpAspNetCoreComponentsServerAntDesignThemeModule)
)]
public class AbpPermissionManagementBlazorServerAntDesignModule : AbpModule
{
}
