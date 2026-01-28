using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AntDesignThemeDomainSharedModule)
)]
public class AntDesignThemeDomainModule : AbpModule
{

}
