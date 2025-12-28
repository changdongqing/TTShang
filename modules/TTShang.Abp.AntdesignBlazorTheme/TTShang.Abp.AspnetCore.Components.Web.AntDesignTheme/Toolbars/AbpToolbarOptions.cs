using System.Collections.Generic;
using JetBrains.Annotations;
using TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.Toolbars;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.Toolbars;

public class AbpToolbarOptions
{
    [NotNull]
    public List<IToolbarContributor> Contributors { get; }

    public AbpToolbarOptions()
    {
        Contributors = new List<IToolbarContributor>();
    }
}
