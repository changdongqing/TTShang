using Volo.Abp.Modularity;

namespace TTShang.TenantManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class TenantManagementApplicationTestBase<TStartupModule> : TenantManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
