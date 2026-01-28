using System.Threading.Tasks;

namespace TTShang.AntDesignTheme.Blazor.Toolbars;

public interface IToolbarManager
{
    Task<Toolbar> GetAsync(string name);
}
