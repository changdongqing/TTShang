using TTShang.IdentityManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TTShang.IdentityManagement.Blazor;

public abstract class IdentityManagementComponentBase : AbpComponentBase
{
    protected IdentityManagementComponentBase()
    {
        LocalizationResource = typeof(IdentityManagementResource);
    }
}