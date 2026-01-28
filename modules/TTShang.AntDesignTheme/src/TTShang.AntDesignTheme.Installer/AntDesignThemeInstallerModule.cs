using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.AntDesignTheme;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AntDesignThemeInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AntDesignThemeInstallerModule>();
        });
    }
}
