using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace TTShang.Abp.AspnetCore.Components.Server.AntDesignTheme.Bundling;

public class BlazorAntDesignThemeStyleContributor: BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/AntDesign/css/ant-design-blazor.css");
        context.Files.AddIfNotContains("/_content/TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme/libs/abp/css/theme.css");
    }
}
