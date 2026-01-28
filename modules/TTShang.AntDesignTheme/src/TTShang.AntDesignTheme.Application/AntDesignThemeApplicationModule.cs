using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AntDesignThemeDomainModule),
    typeof(AntDesignThemeApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpMapperlyModule)
    )]
public class AntDesignThemeApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMapperlyObjectMapper<AntDesignThemeApplicationModule>();
    }
}
