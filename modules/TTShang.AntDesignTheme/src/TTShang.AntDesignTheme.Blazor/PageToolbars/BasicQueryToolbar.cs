using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign;

namespace TTShang.AntDesignTheme.Blazor.PageToolbars;

/// <summary>
/// Basic query toolbar for list pages with default buttons for refresh and export operations.
/// Provides extensibility for adding custom buttons like advanced search or print.
/// </summary>
public class BasicQueryToolbar : PageToolbar
{
    /// <summary>
    /// Callback for refreshing data
    /// </summary>
    public Func<Task>? OnRefresh { get; set; }

    /// <summary>
    /// Callback for exporting data
    /// </summary>
    public Func<Task>? OnExport { get; set; }

    /// <summary>
    /// Controls visibility of the Refresh button
    /// </summary>
    public bool ShowRefreshButton { get; set; } = true;

    /// <summary>
    /// Controls visibility of the Export button
    /// </summary>
    public bool ShowExportButton { get; set; } = true;

    /// <summary>
    /// Text for the Refresh button (localizable)
    /// </summary>
    public string RefreshButtonText { get; set; } = "刷新";

    /// <summary>
    /// Text for the Export button (localizable)
    /// </summary>
    public string ExportButtonText { get; set; } = "导出";

    /// <summary>
    /// Icon for the Refresh button
    /// </summary>
    public string RefreshIcon { get; set; } = "reload";

    /// <summary>
    /// Icon for the Export button
    /// </summary>
    public string ExportIcon { get; set; } = "export";

    /// <summary>
    /// Order of the Refresh button
    /// </summary>
    public int RefreshButtonOrder { get; set; } = 0;

    /// <summary>
    /// Order of the Export button
    /// </summary>
    public int ExportButtonOrder { get; set; } = 1;

    /// <summary>
    /// Policy name required for Refresh button
    /// </summary>
    public string? RefreshRequiredPolicy { get; set; }

    /// <summary>
    /// Policy name required for Export button
    /// </summary>
    public string? ExportRequiredPolicy { get; set; }

    public BasicQueryToolbar()
    {
        // Initialize with default buttons
        InitializeDefaultButtons();
    }

    /// <summary>
    /// Initializes the toolbar with default query buttons
    /// </summary>
    protected virtual void InitializeDefaultButtons()
    {
        // Refresh button
        if (ShowRefreshButton)
        {
            this.AddButton(
                text: RefreshButtonText,
                clicked: OnRefresh ?? (() => Task.CompletedTask),
                icon: RefreshIcon,
                color: ButtonType.Default,
                order: RefreshButtonOrder,
                requiredPolicyName: RefreshRequiredPolicy
            );
        }

        // Export button
        if (ShowExportButton)
        {
            this.AddButton(
                text: ExportButtonText,
                clicked: OnExport ?? (() => Task.CompletedTask),
                icon: ExportIcon,
                color: ButtonType.Primary,
                order: ExportButtonOrder,
                requiredPolicyName: ExportRequiredPolicy
            );
        }
    }

    /// <summary>
    /// Sets the callback for the Refresh button
    /// </summary>
    public BasicQueryToolbar WithRefreshCallback(Func<Task> callback)
    {
        OnRefresh = callback;
        return this;
    }

    /// <summary>
    /// Sets the callback for the Export button
    /// </summary>
    public BasicQueryToolbar WithExportCallback(Func<Task> callback)
    {
        OnExport = callback;
        return this;
    }

    /// <summary>
    /// Adds a custom button to the toolbar for advanced search functionality
    /// </summary>
    public BasicQueryToolbar AddAdvancedSearchButton(
        Func<Task> clicked,
        string text = "高级搜索",
        string icon = "search",
        ButtonType color = ButtonType.Default,
        int order = 10,
        string? requiredPolicyName = null)
    {
        this.AddButton(
            text: text,
            clicked: clicked,
            icon: icon,
            color: color,
            order: order,
            requiredPolicyName: requiredPolicyName
        );

        return this;
    }

    /// <summary>
    /// Adds a custom button to the toolbar for print functionality
    /// </summary>
    public BasicQueryToolbar AddPrintButton(
        Func<Task> clicked,
        string text = "打印",
        string icon = "printer",
        ButtonType color = ButtonType.Default,
        int order = 11,
        string? requiredPolicyName = null)
    {
        this.AddButton(
            text: text,
            clicked: clicked,
            icon: icon,
            color: color,
            order: order,
            requiredPolicyName: requiredPolicyName
        );

        return this;
    }

    /// <summary>
    /// Adds a custom button to the toolbar
    /// </summary>
    public BasicQueryToolbar AddCustomButton(
        string text,
        Func<Task> clicked,
        string? icon = null,
        ButtonType color = ButtonType.Default,
        int order = 100,
        string? requiredPolicyName = null)
    {
        this.AddButton(
            text: text,
            clicked: clicked,
            icon: icon,
            color: color,
            order: order,
            requiredPolicyName: requiredPolicyName
        );

        return this;
    }

    /// <summary>
    /// Configures button visibility
    /// </summary>
    public BasicQueryToolbar ConfigureButtonVisibility(
        bool? showRefresh = null,
        bool? showExport = null)
    {
        if (showRefresh.HasValue)
            ShowRefreshButton = showRefresh.Value;
        if (showExport.HasValue)
            ShowExportButton = showExport.Value;

        return this;
    }
}
