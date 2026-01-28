using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class AntDesignThemeApplicationTestBase<TStartupModule> : AntDesignThemeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
