using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TTShang.PermissionManagement;

[DependsOn(
    typeof(PermissionManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PermissionManagementApplicationContractsModule : AbpModule
{

}
