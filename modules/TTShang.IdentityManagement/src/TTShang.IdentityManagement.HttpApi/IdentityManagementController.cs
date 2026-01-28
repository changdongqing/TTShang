using TTShang.IdentityManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTShang.IdentityManagement;

public abstract class IdentityManagementController : AbpControllerBase
{
    protected IdentityManagementController()
    {
        LocalizationResource = typeof(IdentityManagementResource);
    }
}
