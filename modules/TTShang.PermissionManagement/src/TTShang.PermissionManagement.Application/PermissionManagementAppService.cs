using TTShang.PermissionManagement.Localization;
using Volo.Abp.Application.Services;

namespace TTShang.PermissionManagement;

public abstract class PermissionManagementAppService : ApplicationService
{
    protected PermissionManagementAppService()
    {
        LocalizationResource = typeof(PermissionManagementResource);
        ObjectMapperContext = typeof(PermissionManagementApplicationModule);
    }
}
