using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AntDesignThemeApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AntDesignThemeHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AntDesignThemeApplicationContractsModule).Assembly,
            AntDesignThemeRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AntDesignThemeHttpApiClientModule>();
        });

    }
}
