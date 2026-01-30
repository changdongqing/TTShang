using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(IdentityManagementApplicationContractsModule),
    typeof(AbpIdentityHttpApiClientModule))]
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
