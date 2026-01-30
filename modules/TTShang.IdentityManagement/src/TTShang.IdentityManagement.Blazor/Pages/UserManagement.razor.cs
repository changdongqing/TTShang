using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;
using TTShang.AntDesignUI;
using TTShang.AntDesignTheme.Blazor.PageToolbars;
using TTShang.PermissionManagement.Blazor.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Notifications;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.ObjectExtending;

namespace TTShang.IdentityManagement.Blazor.Pages;

public partial class UserManagement
{
    protected const string PermissionProviderName = "U";

    protected PermissionManagementModal? PermissionManagementModal;
    protected ITable? TableRef;

    [Inject] 
    protected IUiNotificationService NotificationService { get; set; } = default!;

    protected IReadOnlyList<IdentityRoleDto> AvailableRoles = Array.Empty<IdentityRoleDto>();
    protected List<UserEditableRow> EditableUsers = new();
    protected IEnumerable<UserEditableRow> SelectedRows = Array.Empty<UserEditableRow>();
    protected UserEditableRow? SelectedPermissionUser;

    protected bool HasManagePermissionsPermission { get; set; }
    protected bool HasCreatePermission { get; set; }
    protected bool HasUpdatePermission { get; set; }
    protected bool HasDeletePermission { get; set; }

    protected GetIdentityUsersInput QueryModel = new();
    
    // Query fields for filtering (since GetIdentityUsersInput only has Filter property)
    protected string? QueryUserName { get; set; }
    protected string? QueryEmail { get; set; }
    protected string? QueryPhoneNumber { get; set; }
    
    protected bool Loading = false;
    protected int PageSize = 10;
    protected int CurrentPage = 1;
    protected int TotalCount = 0;
    protected string TableScrollY = "400px";

    // Track changes
    protected List<UserEditableRow> AddedRows = new();
    protected List<UserEditableRow> ModifiedRows = new();
    protected List<UserEditableRow> DeletedRows = new();

    protected bool HasChanges => AddedRows.Any() || ModifiedRows.Any() || DeletedRows.Any();

    public UserManagement()
    {
        LocalizationResource = typeof(IdentityResource);
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await SetPermissionsAsync();
        await LoadRolesAsync();
        await SearchAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Calculate table height based on available space
            TableScrollY = "calc(100vh - 350px)";
            StateHasChanged();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    protected virtual async Task SetPermissionsAsync()
    {
        HasCreatePermission = await AuthorizationService.IsGrantedAsync(IdentityPermissions.Users.Create);
        HasUpdatePermission = await AuthorizationService.IsGrantedAsync(IdentityPermissions.Users.Update);
        HasDeletePermission = await AuthorizationService.IsGrantedAsync(IdentityPermissions.Users.Delete);
        HasManagePermissionsPermission = await AuthorizationService.IsGrantedAsync(IdentityPermissions.Users.ManagePermissions);
    }

    protected async Task LoadRolesAsync()
    {
        try
        {
            AvailableRoles = (await UserAppService.GetAssignableRolesAsync()).Items;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected async Task SearchAsync()
    {
        try
        {
            Loading = true;
            CurrentPage = 1;
            
            // Combine filter fields into the Filter property
            var filters = new List<string>();
            if (!string.IsNullOrWhiteSpace(QueryUserName))
                filters.Add(QueryUserName);
            if (!string.IsNullOrWhiteSpace(QueryEmail))
                filters.Add(QueryEmail);
            if (!string.IsNullOrWhiteSpace(QueryPhoneNumber))
                filters.Add(QueryPhoneNumber);
            
            QueryModel.Filter = filters.Any() ? string.Join(" ", filters) : null;
            
            await LoadUsersAsync();
        }
        finally
        {
            Loading = false;
            await InvokeAsync(StateHasChanged);
        }
    }

    protected async Task LoadUsersAsync()
    {
        try
        {
            Loading = true;

            QueryModel.SkipCount = (CurrentPage - 1) * PageSize;
            QueryModel.MaxResultCount = PageSize;

            var result = await UserAppService.GetListAsync(QueryModel);
            TotalCount = (int)result.TotalCount;

            EditableUsers = new List<UserEditableRow>();
            foreach (var user in result.Items)
            {
                var userRoles = await UserAppService.GetRolesAsync(user.Id);
                var row = new UserEditableRow
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsActive = user.IsActive,
                    LockoutEnabled = user.LockoutEnabled,
                    RoleNames = userRoles.Items.Select(r => r.Name).ToArray(),
                    IdNumber = user.GetProperty<string>("IdNumber") ?? string.Empty,
                    IsThirdPartyEmployee = user.GetProperty<bool>("IsThirdPartyEmployee"),
                    IsNew = false,
                    IsEditing = false,
                    IsDeleted = false,
                    IsModified = false,
                    ConcurrencyStamp = user.ConcurrencyStamp
                };
                EditableUsers.Add(row);
            }

            // Clear tracking lists
            AddedRows.Clear();
            ModifiedRows.Clear();
            DeletedRows.Clear();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
        finally
        {
            Loading = false;
        }
    }

    protected async Task OnTableChange(QueryModel<UserEditableRow> queryModel)
    {
        CurrentPage = queryModel.PageIndex;
        await LoadUsersAsync();
        await InvokeAsync(StateHasChanged);
    }

    protected void OnRowClick(RowData<UserEditableRow> rowData)
    {
        // Single click selects the row
        var row = rowData.Data;
        if (row != null && !row.IsDeleted)
        {
            var currentSelected = SelectedRows.ToList();
            if (currentSelected.Contains(row))
            {
                currentSelected.Remove(row);
            }
            else
            {
                currentSelected.Add(row);
            }
            SelectedRows = currentSelected;
        }
    }

    protected void StartEditing(UserEditableRow row)
    {
        if (!row.IsNew && HasUpdatePermission)
        {
            row.IsEditing = true;
            StateHasChanged();
        }
    }

    protected void MarkAsModified(UserEditableRow row)
    {
        if (!row.IsNew && !row.IsModified)
        {
            row.IsModified = true;
            if (!ModifiedRows.Contains(row))
            {
                ModifiedRows.Add(row);
            }
            // Auto-select modified rows
            var currentSelected = SelectedRows.ToList();
            if (!currentSelected.Contains(row))
            {
                currentSelected.Add(row);
                SelectedRows = currentSelected;
            }
        }
        StateHasChanged();
    }

    protected void AddNewRow()
    {
        var newRow = new UserEditableRow
        {
            Id = Guid.NewGuid(),
            UserName = string.Empty,
            Email = string.Empty,
            IsActive = true,
            LockoutEnabled = true,
            RoleNames = Array.Empty<string>(),
            IsNew = true,
            IsEditing = true,
            IsDeleted = false,
            IsModified = false
        };

        EditableUsers.Insert(0, newRow);
        AddedRows.Add(newRow);

        // Auto-select new rows
        var currentSelected = SelectedRows.ToList();
        currentSelected.Add(newRow);
        SelectedRows = currentSelected;

        StateHasChanged();
    }

    protected void DeleteSelectedRows()
    {
        foreach (var row in SelectedRows.ToList())
        {
            if (row.IsNew)
            {
                // Remove new rows completely
                EditableUsers.Remove(row);
                AddedRows.Remove(row);
            }
            else
            {
                // Mark existing rows as deleted
                row.IsDeleted = true;
                if (!DeletedRows.Contains(row))
                {
                    DeletedRows.Add(row);
                }
                // Remove from modified list if present
                ModifiedRows.Remove(row);
            }
        }

        SelectedRows = Array.Empty<UserEditableRow>();
        StateHasChanged();
    }

    protected async Task SaveAllChanges()
    {
        if (!HasChanges)
        {
            await NotificationService.Warn(L["NoChangesToSave"]);
            return;
        }

        try
        {
            Loading = true;

            // Process deletions
            foreach (var row in DeletedRows.ToList())
            {
                await UserAppService.DeleteAsync(row.Id);
            }

            // Process new rows
            foreach (var row in AddedRows.ToList())
            {
                var createDto = new IdentityUserCreateDto
                {
                    UserName = row.UserName ?? string.Empty,
                    Name = row.Name,
                    Surname = row.Surname,
                    Email = row.Email ?? string.Empty,
                    PhoneNumber = row.PhoneNumber,
                    Password = row.Password ?? string.Empty,
                    IsActive = row.IsActive,
                    LockoutEnabled = row.LockoutEnabled,
                    RoleNames = row.RoleNames?.ToArray() ?? Array.Empty<string>()
                };
                createDto.SetProperty("IdNumber", row.IdNumber ?? string.Empty);
                createDto.SetProperty("IsThirdPartyEmployee", row.IsThirdPartyEmployee);

                await UserAppService.CreateAsync(createDto);
            }

            // Process modifications
            foreach (var row in ModifiedRows.ToList())
            {
                var updateDto = new IdentityUserUpdateDto
                {
                    UserName = row.UserName ?? string.Empty,
                    Name = row.Name,
                    Surname = row.Surname,
                    Email = row.Email ?? string.Empty,
                    PhoneNumber = row.PhoneNumber,
                    IsActive = row.IsActive,
                    LockoutEnabled = row.LockoutEnabled,
                    RoleNames = row.RoleNames?.ToArray() ?? Array.Empty<string>(),
                    ConcurrencyStamp = row.ConcurrencyStamp
                };

                // Only set password if provided
                if (!string.IsNullOrWhiteSpace(row.Password))
                {
                    updateDto.Password = row.Password;
                }

                updateDto.SetProperty("IdNumber", row.IdNumber ?? string.Empty);
                updateDto.SetProperty("IsThirdPartyEmployee", row.IsThirdPartyEmployee);

                await UserAppService.UpdateAsync(row.Id, updateDto);
            }

            await NotificationService.Success(L["SaveSuccessful"]);
            await LoadUsersAsync();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
        finally
        {
            Loading = false;
            await InvokeAsync(StateHasChanged);
        }
    }

    protected async Task OpenPermissionsModal()
    {
        var selectedUser = SelectedRows.FirstOrDefault();
        if (selectedUser != null && !selectedUser.IsNew && PermissionManagementModal != null)
        {
            SelectedPermissionUser = selectedUser;
            await PermissionManagementModal.OpenAsync(
                PermissionProviderName,
                selectedUser.Id.ToString(),
                selectedUser.UserName ?? string.Empty);
        }
    }

    protected void ToggleAdvancedQuery()
    {
        // TODO: Implement advanced query modal
        // For now, just show a message
    }
}

public class UserEditableRow
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }
    public bool LockoutEnabled { get; set; }
    public IEnumerable<string>? RoleNames { get; set; }
    public string? IdNumber { get; set; }
    public bool IsThirdPartyEmployee { get; set; }
    public string? ConcurrencyStamp { get; set; }

    // Edit state tracking
    public bool IsNew { get; set; }
    public bool IsEditing { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsModified { get; set; }
}
