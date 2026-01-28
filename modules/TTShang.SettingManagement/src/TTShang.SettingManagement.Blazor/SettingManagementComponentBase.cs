using TTShang.SettingManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TTShang.SettingManagement.Blazor;

public abstract class SettingManagementComponentBase : AbpComponentBase
{
    protected SettingManagementComponentBase()
    {
        LocalizationResource = typeof(SettingManagementResource);
    }
}