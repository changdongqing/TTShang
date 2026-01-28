using TTShang.FeatureManagement.Localization;
using Volo.Abp.Application.Services;

namespace TTShang.FeatureManagement;

public abstract class FeatureManagementAppService : ApplicationService
{
    protected FeatureManagementAppService()
    {
        LocalizationResource = typeof(FeatureManagementResource);
        ObjectMapperContext = typeof(FeatureManagementApplicationModule);
    }
}
