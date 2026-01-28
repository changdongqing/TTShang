using Volo.Abp.Modularity;

namespace TTShang.SettingManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class SettingManagementApplicationTestBase<TStartupModule> : SettingManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
