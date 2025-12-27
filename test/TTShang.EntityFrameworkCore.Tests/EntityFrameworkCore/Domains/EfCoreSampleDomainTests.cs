using TTShang.Samples;
using Xunit;

namespace TTShang.EntityFrameworkCore.Domains;

[Collection(TTShangTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TTShangEntityFrameworkCoreTestModule>
{

}
