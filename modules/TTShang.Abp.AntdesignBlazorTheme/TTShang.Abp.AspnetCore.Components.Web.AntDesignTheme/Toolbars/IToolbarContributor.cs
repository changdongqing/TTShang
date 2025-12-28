using System.Threading.Tasks;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.Toolbars;

public interface IToolbarContributor
{
    Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
}
