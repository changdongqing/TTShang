using System;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.ProLayout;
using TTShang.AntDesignTheme.Blazor.Settings;
using Microsoft.AspNetCore.Components;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Ui.Branding;
using Volo.Abp.AspNetCore.Components.Web.Security;

namespace TTShang.AntDesignTheme.Blazor.Themes.AntDesignTheme;

public partial class DefaultLayout : IDisposable
{
    [Inject]
    protected IAntDesignSettingsProvider AntDesignSettingsProvider { get; set; } = null!;

    [Inject]
    protected IMenuManager MenuManager { get; set; } = null!;

    [Inject]
    protected IBrandingProvider BrandingProvider { get; set; } = null!;

    [Inject]
    protected ApplicationConfigurationChangedService ApplicationConfigurationChangedService { get; set; } = null!;

    protected bool Collapsed { get; set; }

    protected MenuPlacement MenuPlacement { get; set; }

    protected MenuTheme MenuTheme { get; set; }

    protected MenuDataItem[] MenuData { get; set; } = Array.Empty<MenuDataItem>();

    protected string? LogoUrl { get; set; }

    protected string? AppName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await SetLayout();
        await LoadMenuAsync();
        await LoadBrandingAsync();
        
        AntDesignSettingsProvider.SettingChanged += OnSettingChanged;
        ApplicationConfigurationChangedService.Changed += OnApplicationConfigurationChanged;
    }

    protected virtual async Task OnSettingChanged()
    {
        await SetLayout();
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async void OnApplicationConfigurationChanged()
    {
        await LoadMenuAsync();
        await InvokeAsync(StateHasChanged);
    }

    private async Task SetLayout()
    {
        MenuTheme = await AntDesignSettingsProvider.GetMenuThemeAsync();
        MenuPlacement = await AntDesignSettingsProvider.GetMenuPlacementAsync();
    }

    private async Task LoadMenuAsync()
    {
        var menu = await MenuManager.GetMainMenuAsync();
        MenuData = MenuDataItemConverter.ConvertToMenuDataItems(menu);
    }

    private Task LoadBrandingAsync()
    {
        LogoUrl = BrandingProvider.LogoUrl?.TrimStart('/', '~');
        AppName = BrandingProvider.AppName;
        return Task.CompletedTask;
    }

    protected virtual void OnCollapse(bool collapsed)
    {
        Collapsed = collapsed;
    }

    public void Dispose()
    {
        AntDesignSettingsProvider.SettingChanged -= OnSettingChanged;
        ApplicationConfigurationChangedService.Changed -= OnApplicationConfigurationChanged;
    }
}
