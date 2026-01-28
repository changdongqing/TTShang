using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.FeatureManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class FeatureManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FeatureManagementInstallerModule>();
        });
    }
}
