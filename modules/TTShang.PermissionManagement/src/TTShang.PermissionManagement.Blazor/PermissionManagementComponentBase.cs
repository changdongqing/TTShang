using TTShang.PermissionManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TTShang.PermissionManagement.Blazor;

public abstract class PermissionManagementComponentBase : AbpComponentBase
{
    protected PermissionManagementComponentBase()
    {
        LocalizationResource = typeof(PermissionManagementResource);
    }
}