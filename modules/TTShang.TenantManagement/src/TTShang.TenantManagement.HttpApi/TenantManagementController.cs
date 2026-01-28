using TTShang.TenantManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTShang.TenantManagement;

public abstract class TenantManagementController : AbpControllerBase
{
    protected TenantManagementController()
    {
        LocalizationResource = typeof(TenantManagementResource);
    }
}
