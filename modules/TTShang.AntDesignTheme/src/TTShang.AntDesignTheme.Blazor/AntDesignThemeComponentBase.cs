using TTShang.AntDesignTheme.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TTShang.AntDesignTheme.Blazor;

public abstract class AntDesignThemeComponentBase : AbpComponentBase
{
    protected AntDesignThemeComponentBase()
    {
        LocalizationResource = typeof(AntDesignThemeResource);
    }
}