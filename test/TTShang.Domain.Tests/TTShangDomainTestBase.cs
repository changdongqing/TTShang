using Volo.Abp.Modularity;

namespace TTShang;

/* Inherit from this class for your domain layer tests. */
public abstract class TTShangDomainTestBase<TStartupModule> : TTShangTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
