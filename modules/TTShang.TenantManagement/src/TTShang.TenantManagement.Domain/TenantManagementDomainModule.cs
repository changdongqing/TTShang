using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TTShang.TenantManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(TenantManagementDomainSharedModule)
)]
public class TenantManagementDomainModule : AbpModule
{

}
