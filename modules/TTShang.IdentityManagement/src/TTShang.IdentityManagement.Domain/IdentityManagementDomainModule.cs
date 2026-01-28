using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(IdentityManagementDomainSharedModule)
)]
public class IdentityManagementDomainModule : AbpModule
{

}
