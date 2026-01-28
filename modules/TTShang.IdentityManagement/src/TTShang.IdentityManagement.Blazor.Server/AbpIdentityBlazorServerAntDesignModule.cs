using TTShang.IdentityManagement.Blazor;
using TTShang.PermissionManagement.Blazor;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement.Blazor.Server;

[DependsOn(
    typeof(AbpIdentityBlazorAntDesignModule),
    typeof(AbpPermissionManagementBlazorAntDesignModule)
)]
public class AbpIdentityBlazorServerAntDesignModule : AbpModule
{
    
}
