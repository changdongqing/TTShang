using System.Threading.Tasks;
using TTShang.AntDesignTheme.Blazor.PageToolbars;

namespace TTShang.AntDesignTheme.Blazor.PageToolbars;

public abstract class PageToolbarContributor : IPageToolbarContributor
{
    public abstract Task ContributeAsync(PageToolbarContributionContext context);
}
