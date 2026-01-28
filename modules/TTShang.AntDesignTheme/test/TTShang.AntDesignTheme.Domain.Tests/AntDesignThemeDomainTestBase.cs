using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class AntDesignThemeDomainTestBase<TStartupModule> : AntDesignThemeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
