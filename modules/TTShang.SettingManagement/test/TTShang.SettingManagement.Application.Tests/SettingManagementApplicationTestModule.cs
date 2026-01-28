using Volo.Abp.Modularity;

namespace TTShang.SettingManagement;

[DependsOn(
    typeof(SettingManagementApplicationModule),
    typeof(SettingManagementDomainTestModule)
    )]
public class SettingManagementApplicationTestModule : AbpModule
{

}
