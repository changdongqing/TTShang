using AntDesign;
using TTShang.AntDesignTheme.Blazor.Settings;

namespace TTShang.AntDesignTheme.Blazor;

public class AbpAntDesignThemeOptions
{
    public MenuOptions Menu { get; set; }

    /// <summary>
    /// Enable multiple tabs in the application.
    /// </summary>
    public bool EnableMultipleTabs { get; set; }

    public AbpAntDesignThemeOptions()
    {
        Menu = new MenuOptions();
    }
}

public class MenuOptions
{
    public MenuTheme Theme { get; set; }

    public MenuPlacement Placement { get; set; }

    public MenuOptions()
    {
        Theme = MenuTheme.Dark;
        Placement = MenuPlacement.Left;
    }
}
