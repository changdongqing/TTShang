using System.Threading.Tasks;
using TTShang.AntDesignTheme.Blazor.Server.Themes.AntDesignTheme;
using TTShang.AntDesignTheme.Blazor.Toolbars;

namespace TTShang.AntDesignTheme.Blazor.Server;


public class AntDesignThemeToolbarContributor: IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
        }

        return Task.CompletedTask;
    }
}
