using Volo.Abp.Modularity;

namespace TTShang;

[DependsOn(
    typeof(TTShangApplicationModule),
    typeof(TTShangDomainTestModule)
)]
public class TTShangApplicationTestModule : AbpModule
{

}
