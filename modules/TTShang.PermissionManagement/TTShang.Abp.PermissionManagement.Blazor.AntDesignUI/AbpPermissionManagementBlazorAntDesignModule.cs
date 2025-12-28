using TTShang.Abp.AntDesignUI;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace TTShang.Abp.PermissionManagement.Blazor.AntDesignUI;

[DependsOn(
    typeof(AbpAntDesignUIModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
public class AbpPermissionManagementBlazorAntDesignModule : AbpModule
{

}
