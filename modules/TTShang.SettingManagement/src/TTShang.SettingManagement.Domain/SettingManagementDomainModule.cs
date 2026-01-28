using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TTShang.SettingManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SettingManagementDomainSharedModule)
)]
public class SettingManagementDomainModule : AbpModule
{

}
