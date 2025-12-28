using System.Threading.Tasks;
using TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.PageToolbars;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.PageToolbars;

public abstract class PageToolbarContributor : IPageToolbarContributor
{
    public abstract Task ContributeAsync(PageToolbarContributionContext context);
}
