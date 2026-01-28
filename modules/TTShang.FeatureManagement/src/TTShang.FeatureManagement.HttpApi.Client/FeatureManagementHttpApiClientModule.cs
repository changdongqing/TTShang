using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(FeatureManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class FeatureManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(FeatureManagementApplicationContractsModule).Assembly,
            FeatureManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FeatureManagementHttpApiClientModule>();
        });

    }
}
