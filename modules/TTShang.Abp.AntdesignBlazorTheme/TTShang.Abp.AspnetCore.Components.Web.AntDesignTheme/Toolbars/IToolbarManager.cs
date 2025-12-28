using System.Threading.Tasks;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.Toolbars;

public interface IToolbarManager
{
    Task<Toolbar> GetAsync(string name);
}
