using TTShang.PermissionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTShang.PermissionManagement;

public abstract class PermissionManagementController : AbpControllerBase
{
    protected PermissionManagementController()
    {
        LocalizationResource = typeof(PermissionManagementResource);
    }
}
