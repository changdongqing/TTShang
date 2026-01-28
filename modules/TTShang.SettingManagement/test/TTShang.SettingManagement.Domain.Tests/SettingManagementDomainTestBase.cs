using Volo.Abp.Modularity;

namespace TTShang.SettingManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class SettingManagementDomainTestBase<TStartupModule> : SettingManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
