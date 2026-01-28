using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace TTShang.AntDesignTheme.Blazor.Server.Bundling;

public class BlazorAntDesignThemeScriptContributor: BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/AntDesign/js/ant-design-blazor.js");
    }
}
