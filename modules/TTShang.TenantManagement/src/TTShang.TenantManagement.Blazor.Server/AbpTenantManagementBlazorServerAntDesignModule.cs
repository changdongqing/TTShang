using TTShang.FeatureManagement.Blazor.Server;
using TTShang.TenantManagement.Blazor;
using Volo.Abp.Modularity;

namespace TTShang.TenantManagement.Blazor.Server;

[DependsOn(
    typeof(AbpTenantManagementBlazorAntDesignModule),
    typeof(AbpFeatureManagementBlazorServerAntDesignModule)
)]
public class AbpTenantManagementBlazorServerAntDesignModule : AbpModule
{
    
}
