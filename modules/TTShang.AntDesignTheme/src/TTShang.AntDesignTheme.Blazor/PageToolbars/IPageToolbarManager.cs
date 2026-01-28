using System.Threading.Tasks;

namespace TTShang.AntDesignTheme.Blazor.PageToolbars;

public interface IPageToolbarManager
{
    Task<PageToolbarItem[]> GetItemsAsync(PageToolbar toolbar);
}
