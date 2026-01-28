using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AntDesignThemeApplicationModule),
    typeof(AntDesignThemeDomainTestModule)
    )]
public class AntDesignThemeApplicationTestModule : AbpModule
{

}
