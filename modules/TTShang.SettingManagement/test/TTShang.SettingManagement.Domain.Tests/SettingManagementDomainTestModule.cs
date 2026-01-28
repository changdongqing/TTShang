using Volo.Abp.Modularity;

namespace TTShang.SettingManagement;

[DependsOn(
    typeof(SettingManagementDomainModule),
    typeof(SettingManagementTestBaseModule)
)]
public class SettingManagementDomainTestModule : AbpModule
{

}
