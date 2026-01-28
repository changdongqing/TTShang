using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AntDesignThemeDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AntDesignThemeApplicationContractsModule : AbpModule
{

}
