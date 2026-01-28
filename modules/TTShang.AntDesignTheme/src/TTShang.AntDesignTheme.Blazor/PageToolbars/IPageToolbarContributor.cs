using System.Threading.Tasks;
using TTShang.AntDesignTheme.Blazor.PageToolbars;

namespace TTShang.AntDesignTheme.Blazor.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}
