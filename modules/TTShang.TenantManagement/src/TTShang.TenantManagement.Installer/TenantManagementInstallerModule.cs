using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.TenantManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class TenantManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TenantManagementInstallerModule>();
        });
    }
}
