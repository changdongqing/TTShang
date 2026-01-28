using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementApplicationModule),
    typeof(IdentityManagementDomainTestModule)
    )]
public class IdentityManagementApplicationTestModule : AbpModule
{

}
