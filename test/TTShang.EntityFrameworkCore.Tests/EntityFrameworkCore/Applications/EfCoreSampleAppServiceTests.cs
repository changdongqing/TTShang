using TTShang.Samples;
using Xunit;

namespace TTShang.EntityFrameworkCore.Applications;

[Collection(TTShangTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TTShangEntityFrameworkCoreTestModule>
{

}
