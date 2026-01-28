using Volo.Abp.Modularity;

namespace TTShang;

[DependsOn(
    typeof(TTShangDomainModule),
    typeof(TTShangTestBaseModule)
)]
public class TTShangDomainTestModule : AbpModule
{

}
