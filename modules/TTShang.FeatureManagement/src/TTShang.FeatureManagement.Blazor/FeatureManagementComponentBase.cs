using TTShang.FeatureManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TTShang.FeatureManagement.Blazor;

public abstract class FeatureManagementComponentBase : AbpComponentBase
{
    protected FeatureManagementComponentBase()
    {
        LocalizationResource = typeof(FeatureManagementResource);
    }
}