using TTShang.SettingManagement.Localization;
using Volo.Abp.Application.Services;

namespace TTShang.SettingManagement;

public abstract class SettingManagementAppService : ApplicationService
{
    protected SettingManagementAppService()
    {
        LocalizationResource = typeof(SettingManagementResource);
        ObjectMapperContext = typeof(SettingManagementApplicationModule);
    }
}
