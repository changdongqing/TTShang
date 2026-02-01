using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;
using TTShang.AntDesignTheme.Blazor.Components;
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
    protected bool HasUpdatePermission { get; set; }

    protected GetIdentityUsersInput QueryModel = new();
    
    // Query fields for filtering (since GetIdentityUsersInput only has Filter property)
    protected string? QueryUserName { get; set; }
    protected string? QueryEmail { get; set; }
    protected string? QueryPhoneNumber { get; set; }
    
    protected bool Loading = false;
    protected int PageSize = 10;
    protected int CurrentPage = 1;
    protected int TotalCount = 0;
    
    /// <summary>
    /// Table scroll height calculation: viewport minus fixed UI elements.
    /// Components: header(48px) + tabs(~40px) + toolbar(~50px) + query(~120px) + margins(~40px) + pagination(~50px) + table header(~40px) = ~390px
    /// </summary>
    protected string TableScrollY = "calc(100vh - 390px)";
    
    /// <summary>
    /// Horizontal scroll width for the table based on sum of column widths.
    /// Columns: Selection(60) + Index(60) + UserName(120) + Surname(100) + Name(100) + Email(180) + Phone(130) + Password(120) + IdNumber(180) + IsThirdParty(120) + IsActive(80) + LockoutEnabled(100) + Roles(200) ≈ 1550px, rounded to 1500px minimum.
    /// </summary>
    protected string TableScrollX = "1500";

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
        await base.OnAfterRenderAsync(firstRender);
    }

    protected virtual async Task SetPermissionsAsync()
    {
        HasUpdatePermission = await AuthorizationService.IsGrantedAsync(IdentityPermissions.Users.Update);
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

            Console.WriteLine($"Loaded {result.Items.Count} users for page {CurrentPage}");

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

            Console.WriteLine($"EditableUsers count: {EditableUsers.Count}");

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
        if (Loading) return;
        CurrentPage = queryModel.PageIndex;
        await LoadUsersAsync();
        await InvokeAsync(StateHasChanged);
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

    protected UserEditableRow CreateNewRow()
    {
        return new UserEditableRow
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
    }

    protected async Task OnChangesSavedAsync()
    {
        await NotificationService.Success(L["SaveSuccessful"]);
        await LoadUsersAsync();
    }

    protected async Task OnNoChangesAsync()
    {
        await NotificationService.Warn(L["NoChangesToSave"]);
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

public class UserEditableRow : ISingleTableEditableRow<IdentityUserCreateDto, IdentityUserUpdateDto, Guid>
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

    public IdentityUserCreateDto ToCreateDto()
    {
        var createDto = new IdentityUserCreateDto
        {
            UserName = UserName ?? string.Empty,
            Name = Name,
            Surname = Surname,
            Email = Email ?? string.Empty,
            PhoneNumber = PhoneNumber,
            Password = Password ?? string.Empty,
            IsActive = IsActive,
            LockoutEnabled = LockoutEnabled,
            RoleNames = RoleNames?.ToArray() ?? Array.Empty<string>()
        };
        createDto.SetProperty("IdNumber", IdNumber ?? string.Empty);
        createDto.SetProperty("IsThirdPartyEmployee", IsThirdPartyEmployee);
        return createDto;
    }

    public IdentityUserUpdateDto ToUpdateDto()
    {
        var updateDto = new IdentityUserUpdateDto
        {
            UserName = UserName ?? string.Empty,
            Name = Name,
            Surname = Surname,
            Email = Email ?? string.Empty,
            PhoneNumber = PhoneNumber,
            IsActive = IsActive,
            LockoutEnabled = LockoutEnabled,
            RoleNames = RoleNames?.ToArray() ?? Array.Empty<string>(),
            ConcurrencyStamp = ConcurrencyStamp
        };

        if (!string.IsNullOrWhiteSpace(Password))
        {
            updateDto.Password = Password;
        }

        updateDto.SetProperty("IdNumber", IdNumber ?? string.Empty);
        updateDto.SetProperty("IsThirdPartyEmployee", IsThirdPartyEmployee);
        return updateDto;
    }
}
