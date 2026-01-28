using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(FeatureManagementApplicationModule),
    typeof(FeatureManagementDomainTestModule)
    )]
public class FeatureManagementApplicationTestModule : AbpModule
{

}
