using Volo.Abp.Modularity;

namespace TTShang.TenantManagement;

[DependsOn(
    typeof(TenantManagementDomainModule),
    typeof(TenantManagementTestBaseModule)
)]
public class TenantManagementDomainTestModule : AbpModule
{

}
