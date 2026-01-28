using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(FeatureManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class FeatureManagementApplicationContractsModule : AbpModule
{

}
