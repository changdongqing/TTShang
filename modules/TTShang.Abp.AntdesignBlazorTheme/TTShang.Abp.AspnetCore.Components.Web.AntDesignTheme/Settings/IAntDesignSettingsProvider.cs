using System;
using System.Threading.Tasks;
using AntDesign;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;

public interface IAntDesignSettingsProvider
{
    Task<MenuPlacement> GetMenuPlacementAsync();

    Task<MenuTheme> GetMenuThemeAsync();

    Task TriggerSettingChanged();
    
    public event AntDesignSettingsProvider.AntDesignSettingChangedHandler SettingChanged;
}
