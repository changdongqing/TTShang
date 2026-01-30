using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementDomainSharedModule),
    typeof(AbpIdentityApplicationContractsModule)
    )]
public class IdentityManagementApplicationContractsModule : AbpModule
{

}
