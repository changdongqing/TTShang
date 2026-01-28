using TTShang.SettingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTShang.SettingManagement;

public abstract class SettingManagementController : AbpControllerBase
{
    protected SettingManagementController()
    {
        LocalizationResource = typeof(SettingManagementResource);
    }
}
