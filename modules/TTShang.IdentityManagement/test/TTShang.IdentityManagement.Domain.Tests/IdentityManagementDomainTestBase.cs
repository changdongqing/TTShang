using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class IdentityManagementDomainTestBase<TStartupModule> : IdentityManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
