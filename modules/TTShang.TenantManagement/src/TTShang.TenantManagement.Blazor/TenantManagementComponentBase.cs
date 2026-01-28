using TTShang.TenantManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TTShang.TenantManagement.Blazor;

public abstract class TenantManagementComponentBase : AbpComponentBase
{
    protected TenantManagementComponentBase()
    {
        LocalizationResource = typeof(TenantManagementResource);
    }
}