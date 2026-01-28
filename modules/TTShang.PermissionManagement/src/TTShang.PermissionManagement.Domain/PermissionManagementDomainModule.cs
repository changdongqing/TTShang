using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TTShang.PermissionManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PermissionManagementDomainSharedModule)
)]
public class PermissionManagementDomainModule : AbpModule
{

}
