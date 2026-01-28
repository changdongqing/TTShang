using Volo.Abp.Modularity;

namespace TTShang.PermissionManagement;

[DependsOn(
    typeof(PermissionManagementApplicationModule),
    typeof(PermissionManagementDomainTestModule)
    )]
public class PermissionManagementApplicationTestModule : AbpModule
{

}
