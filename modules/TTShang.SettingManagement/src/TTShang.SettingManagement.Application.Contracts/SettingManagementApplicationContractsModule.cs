using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TTShang.SettingManagement;

[DependsOn(
    typeof(SettingManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SettingManagementApplicationContractsModule : AbpModule
{

}
