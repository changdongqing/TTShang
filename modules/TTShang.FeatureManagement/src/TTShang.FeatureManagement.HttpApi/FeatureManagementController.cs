using TTShang.FeatureManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTShang.FeatureManagement;

public abstract class FeatureManagementController : AbpControllerBase
{
    protected FeatureManagementController()
    {
        LocalizationResource = typeof(FeatureManagementResource);
    }
}
