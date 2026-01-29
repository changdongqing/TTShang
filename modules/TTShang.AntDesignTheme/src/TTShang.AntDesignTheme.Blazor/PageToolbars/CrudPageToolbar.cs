using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign;
using Volo.Abp.Application.Dtos;

namespace TTShang.AntDesignTheme.Blazor.PageToolbars;

/// <summary>
/// Page toolbar for CRUD operations with default buttons for add, delete, and save actions.
/// Designed for inline editing or grid data manipulation scenarios.
/// </summary>
/// <typeparam name="TEntityDto">The entity DTO type</typeparam>
/// <typeparam name="TKey">The key type of the entity</typeparam>
public class CrudPageToolbar<TEntityDto, TKey> : PageToolbar
    where TEntityDto : IEntityDto<TKey>
{
    /// <summary>
    /// Callback for adding a new row
    /// </summary>
    public Func<Task>? OnAddRow { get; set; }

    /// <summary>
    /// Callback for deleting selected rows
    /// </summary>
    public Func<Task>? OnDeleteRow { get; set; }

    /// <summary>
    /// Callback for saving changes
    /// </summary>
    public Func<Task>? OnSave { get; set; }

    /// <summary>
    /// Controls visibility of the Add Row button
    /// </summary>
    public bool ShowAddRowButton { get; set; } = true;

    /// <summary>
    /// Controls visibility of the Delete Row button
    /// </summary>
    public bool ShowDeleteRowButton { get; set; } = true;

    /// <summary>
    /// Controls visibility of the Save button
    /// </summary>
    public bool ShowSaveButton { get; set; } = true;

    /// <summary>
    /// Text for the Add Row button (localizable)
    /// </summary>
    public string AddRowButtonText { get; set; } = "增行";

    /// <summary>
    /// Text for the Delete Row button (localizable)
    /// </summary>
    public string DeleteRowButtonText { get; set; } = "删行";

    /// <summary>
    /// Text for the Save button (localizable)
    /// </summary>
    public string SaveButtonText { get; set; } = "保存";

    /// <summary>
    /// Icon for the Add Row button
    /// </summary>
    public string AddRowIcon { get; set; } = "plus";

    /// <summary>
    /// Icon for the Delete Row button
    /// </summary>
    public string DeleteRowIcon { get; set; } = "delete";

    /// <summary>
    /// Icon for the Save button
    /// </summary>
    public string SaveIcon { get; set; } = "save";

    /// <summary>
    /// Order of the Add Row button
    /// </summary>
    public int AddRowButtonOrder { get; set; } = 0;

    /// <summary>
    /// Order of the Delete Row button
    /// </summary>
    public int DeleteRowButtonOrder { get; set; } = 1;

    /// <summary>
    /// Order of the Save button
    /// </summary>
    public int SaveButtonOrder { get; set; } = 2;

    /// <summary>
    /// Policy name required for Add Row button
    /// </summary>
    public string? AddRowRequiredPolicy { get; set; }

    /// <summary>
    /// Policy name required for Delete Row button
    /// </summary>
    public string? DeleteRowRequiredPolicy { get; set; }

    /// <summary>
    /// Policy name required for Save button
    /// </summary>
    public string? SaveRequiredPolicy { get; set; }

    public CrudPageToolbar()
    {
        // Initialize with default buttons
        InitializeDefaultButtons();
    }

    /// <summary>
    /// Initializes the toolbar with default CRUD buttons
    /// </summary>
    protected virtual void InitializeDefaultButtons()
    {
        // Add Row button
        if (ShowAddRowButton)
        {
            this.AddButton(
                text: AddRowButtonText,
                clicked: OnAddRow ?? (() => Task.CompletedTask),
                icon: AddRowIcon,
                color: ButtonType.Primary,
                order: AddRowButtonOrder,
                requiredPolicyName: AddRowRequiredPolicy
            );
        }

        // Delete Row button with danger styling
        if (ShowDeleteRowButton)
        {
            this.AddButton(
                text: DeleteRowButtonText,
                clicked: OnDeleteRow ?? (() => Task.CompletedTask),
                icon: DeleteRowIcon,
                color: ButtonType.Primary,
                danger: true,
                order: DeleteRowButtonOrder,
                requiredPolicyName: DeleteRowRequiredPolicy
            );
        }

        // Save button
        if (ShowSaveButton)
        {
            this.AddButton(
                text: SaveButtonText,
                clicked: OnSave ?? (() => Task.CompletedTask),
                icon: SaveIcon,
                color: ButtonType.Primary,
                order: SaveButtonOrder,
                requiredPolicyName: SaveRequiredPolicy
            );
        }
    }

    /// <summary>
    /// Rebuilds the toolbar with current settings. Call this after changing button properties or visibility.
    /// </summary>
    public virtual void Rebuild()
    {
        Contributors.Clear();
        InitializeDefaultButtons();
    }

    /// <summary>
    /// Sets the callback for the Add Row button
    /// </summary>
    public CrudPageToolbar<TEntityDto, TKey> WithAddRowCallback(Func<Task> callback)
    {
        OnAddRow = callback;
        return this;
    }

    /// <summary>
    /// Sets the callback for the Delete Row button
    /// </summary>
    public CrudPageToolbar<TEntityDto, TKey> WithDeleteRowCallback(Func<Task> callback)
    {
        OnDeleteRow = callback;
        return this;
    }

    /// <summary>
    /// Sets the callback for the Save button
    /// </summary>
    public CrudPageToolbar<TEntityDto, TKey> WithSaveCallback(Func<Task> callback)
    {
        OnSave = callback;
        return this;
    }

    /// <summary>
    /// Configures button visibility
    /// </summary>
    public CrudPageToolbar<TEntityDto, TKey> ConfigureButtonVisibility(
        bool? showAddRow = null,
        bool? showDeleteRow = null,
        bool? showSave = null)
    {
        if (showAddRow.HasValue)
            ShowAddRowButton = showAddRow.Value;
        if (showDeleteRow.HasValue)
            ShowDeleteRowButton = showDeleteRow.Value;
        if (showSave.HasValue)
            ShowSaveButton = showSave.Value;
        
        Rebuild();
        return this;
    }
}
