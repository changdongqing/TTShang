using Volo.Abp.Modularity;

namespace TTShang.TenantManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class TenantManagementDomainTestBase<TStartupModule> : TenantManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
