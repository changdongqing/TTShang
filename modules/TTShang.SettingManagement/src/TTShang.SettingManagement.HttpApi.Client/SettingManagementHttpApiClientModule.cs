using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.SettingManagement;

[DependsOn(
    typeof(SettingManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SettingManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SettingManagementApplicationContractsModule).Assembly,
            SettingManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SettingManagementHttpApiClientModule>();
        });

    }
}
