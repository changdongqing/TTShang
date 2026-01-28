using TTShang.AntDesignTheme.Localization;
using Volo.Abp.Application.Services;

namespace TTShang.AntDesignTheme;

public abstract class AntDesignThemeAppService : ApplicationService
{
    protected AntDesignThemeAppService()
    {
        LocalizationResource = typeof(AntDesignThemeResource);
        ObjectMapperContext = typeof(AntDesignThemeApplicationModule);
    }
}
