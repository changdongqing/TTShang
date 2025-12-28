using TTShang.Abp.IdentityManagement.Blazor.AntDesignUI;
using TTShang.Abp.PermissionManagement.Blazor.AntDesignUI;
using Volo.Abp.Modularity;

namespace TTShang.Abp.IdentityManagement.Blazor.Server.AntDesignUI;

[DependsOn(
    typeof(AbpIdentityBlazorAntDesignModule),
    typeof(AbpPermissionManagementBlazorAntDesignModule)
)]
public class AbpIdentityBlazorServerAntDesignModule : AbpModule
{
    
}
