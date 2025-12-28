using TTShang.Abp.IdentityManagement.Blazor.AntDesignUI;
using TTShang.Abp.PermissionManagement.Blazor.WebAssembly.AntDesignUI;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace TTShang.Abp.IdentityManagement.Blazor.WebAssembly.AntDesignUI;

[DependsOn(
    typeof(AbpIdentityBlazorAntDesignModule),
    typeof(AbpPermissionManagementBlazorWebAssemblyAntDesignModule),
    typeof(AbpIdentityHttpApiClientModule)
)]
public class AbpIdentityBlazorWebAssemblyAntDesignModule: AbpModule
{
}
