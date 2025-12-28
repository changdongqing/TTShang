using System.Threading.Tasks;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.PageToolbars;

public interface IPageToolbarManager
{
    Task<PageToolbarItem[]> GetItemsAsync(PageToolbar toolbar);
}
