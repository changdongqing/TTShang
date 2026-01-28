using TTShang.TenantManagement.Localization;
using Volo.Abp.Application.Services;

namespace TTShang.TenantManagement;

public abstract class TenantManagementAppService : ApplicationService
{
    protected TenantManagementAppService()
    {
        LocalizationResource = typeof(TenantManagementResource);
        ObjectMapperContext = typeof(TenantManagementApplicationModule);
    }
}
