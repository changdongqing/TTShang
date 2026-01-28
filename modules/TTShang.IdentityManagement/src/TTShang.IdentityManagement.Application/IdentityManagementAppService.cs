using TTShang.IdentityManagement.Localization;
using Volo.Abp.Application.Services;

namespace TTShang.IdentityManagement;

public abstract class IdentityManagementAppService : ApplicationService
{
    protected IdentityManagementAppService()
    {
        LocalizationResource = typeof(IdentityManagementResource);
        ObjectMapperContext = typeof(IdentityManagementApplicationModule);
    }
}
