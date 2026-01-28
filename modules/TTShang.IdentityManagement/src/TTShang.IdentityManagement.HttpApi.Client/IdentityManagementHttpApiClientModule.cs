using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class IdentityManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(IdentityManagementApplicationContractsModule).Assembly,
            IdentityManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityManagementHttpApiClientModule>();
        });

    }
}
