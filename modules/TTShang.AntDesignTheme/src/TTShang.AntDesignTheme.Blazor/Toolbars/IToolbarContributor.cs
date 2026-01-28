using System.Threading.Tasks;

namespace TTShang.AntDesignTheme.Blazor.Toolbars;

public interface IToolbarContributor
{
    Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
}
