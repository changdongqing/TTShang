using System.Threading.Tasks;
using TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.PageToolbars;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}
