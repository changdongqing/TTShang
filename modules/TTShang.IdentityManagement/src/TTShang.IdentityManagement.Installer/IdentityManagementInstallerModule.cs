using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class IdentityManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityManagementInstallerModule>();
        });
    }
}
