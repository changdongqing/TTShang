using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AntDesignThemeDomainModule),
    typeof(AntDesignThemeTestBaseModule)
)]
public class AntDesignThemeDomainTestModule : AbpModule
{

}
