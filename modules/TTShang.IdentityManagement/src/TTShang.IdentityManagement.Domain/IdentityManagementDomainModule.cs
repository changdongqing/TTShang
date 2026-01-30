using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(AbpIdentityDomainModule),
    typeof(IdentityManagementDomainSharedModule)
)]
public class IdentityManagementDomainModule : AbpModule
{

}
