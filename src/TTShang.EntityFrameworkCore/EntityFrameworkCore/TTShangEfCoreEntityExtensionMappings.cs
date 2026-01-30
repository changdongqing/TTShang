using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace TTShang.EntityFrameworkCore;

public static class TTShangEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        TTShangGlobalFeatureConfigurator.Configure();
        TTShangModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, string>(
                    "IdNumber",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(18);
                    }
                );

            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, bool>(
                    "IsThirdPartyEmployee",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasDefaultValue(false);
                    }
                );
        });
    }
}
