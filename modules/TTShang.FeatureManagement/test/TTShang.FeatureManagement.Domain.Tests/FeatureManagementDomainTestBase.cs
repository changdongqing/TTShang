using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class FeatureManagementDomainTestBase<TStartupModule> : FeatureManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
