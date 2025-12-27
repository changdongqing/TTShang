using TTShang.Books;
using Xunit;

namespace TTShang.EntityFrameworkCore.Applications.Books;

[Collection(TTShangTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<TTShangEntityFrameworkCoreTestModule>
{

}