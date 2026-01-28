using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TTShang.TenantManagement;

[DependsOn(
    typeof(TenantManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class TenantManagementApplicationContractsModule : AbpModule
{

}
