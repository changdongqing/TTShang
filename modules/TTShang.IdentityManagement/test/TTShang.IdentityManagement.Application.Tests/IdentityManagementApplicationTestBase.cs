using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class IdentityManagementApplicationTestBase<TStartupModule> : IdentityManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
