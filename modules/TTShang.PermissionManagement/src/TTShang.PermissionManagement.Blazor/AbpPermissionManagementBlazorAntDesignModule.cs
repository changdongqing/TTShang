using TTShang.AntDesignUI;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace TTShang.PermissionManagement.Blazor;

[DependsOn(
    typeof(AbpAntDesignUIModule),
    typeof(AbpMapperlyModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
public class AbpPermissionManagementBlazorAntDesignModule : AbpModule
{

}
