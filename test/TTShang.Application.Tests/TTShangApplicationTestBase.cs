using Volo.Abp.Modularity;

namespace TTShang;

public abstract class TTShangApplicationTestBase<TStartupModule> : TTShangTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
