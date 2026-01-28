using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class IdentityManagementApplicationContractsModule : AbpModule
{

}
