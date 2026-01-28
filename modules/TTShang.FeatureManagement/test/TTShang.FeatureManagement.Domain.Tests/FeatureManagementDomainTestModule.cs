using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(FeatureManagementDomainModule),
    typeof(FeatureManagementTestBaseModule)
)]
public class FeatureManagementDomainTestModule : AbpModule
{

}
