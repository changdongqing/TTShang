using Xunit;

namespace TTShang.EntityFrameworkCore;

[CollectionDefinition(TTShangTestConsts.CollectionDefinitionName)]
public class TTShangEntityFrameworkCoreCollection : ICollectionFixture<TTShangEntityFrameworkCoreFixture>
{

}
