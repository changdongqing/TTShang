using TTShang.Abp.FeatureManagement.Blazor.Server.AntDesignUI;
using TTShang.Abp.TenantManagement.Blazor.AntDesignUI;
using Volo.Abp.Modularity;

namespace TTShang.Abp.TenantManagement.Blazor.Server.AntDesignUI;

[DependsOn(
    typeof(AbpTenantManagementBlazorAntDesignModule),
    typeof(AbpFeatureManagementBlazorServerAntDesignModule)
)]
public class AbpTenantManagementBlazorServerAntDesignModule : AbpModule
{
    
}
