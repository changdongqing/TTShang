using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementDomainModule),
    typeof(IdentityManagementTestBaseModule)
)]
public class IdentityManagementDomainTestModule : AbpModule
{

}
