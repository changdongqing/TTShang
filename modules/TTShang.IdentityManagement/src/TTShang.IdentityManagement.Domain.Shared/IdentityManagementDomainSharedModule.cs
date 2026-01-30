using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using TTShang.IdentityManagement.Localization;
using Volo.Abp.Identity;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace TTShang.IdentityManagement;

[DependsOn(
    typeof(AbpIdentityDomainSharedModule)
)]
public class IdentityManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityManagementDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<IdentityManagementResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/IdentityManagement");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("IdentityManagement", typeof(IdentityManagementResource));
        });
    }
}
