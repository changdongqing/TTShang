using Volo.Abp.Modularity;

namespace TTShang.PermissionManagement;

[DependsOn(
    typeof(PermissionManagementDomainModule),
    typeof(PermissionManagementTestBaseModule)
)]
public class PermissionManagementDomainTestModule : AbpModule
{

}
