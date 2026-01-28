using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(FeatureManagementDomainSharedModule)
)]
public class FeatureManagementDomainModule : AbpModule
{

}
