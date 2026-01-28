using Volo.Abp.Modularity;

namespace TTShang.TenantManagement;

[DependsOn(
    typeof(TenantManagementApplicationModule),
    typeof(TenantManagementDomainTestModule)
    )]
public class TenantManagementApplicationTestModule : AbpModule
{

}
