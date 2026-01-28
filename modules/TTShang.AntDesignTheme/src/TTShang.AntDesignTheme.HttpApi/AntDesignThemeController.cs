using TTShang.AntDesignTheme.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTShang.AntDesignTheme;

public abstract class AntDesignThemeController : AbpControllerBase
{
    protected AntDesignThemeController()
    {
        LocalizationResource = typeof(AntDesignThemeResource);
    }
}
