using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementDomainModule),
    typeof(IdentityManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationModule)
    )]
public class IdentityManagementApplicationModule : AbpModule
{
}
