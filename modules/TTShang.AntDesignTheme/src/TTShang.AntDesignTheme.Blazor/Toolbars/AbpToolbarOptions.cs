using System.Collections.Generic;
using JetBrains.Annotations;
using TTShang.AntDesignTheme.Blazor.Toolbars;

namespace TTShang.AntDesignTheme.Blazor.Toolbars;

public class AbpToolbarOptions
{
    [NotNull]
    public List<IToolbarContributor> Contributors { get; }

    public AbpToolbarOptions()
    {
        Contributors = new List<IToolbarContributor>();
    }
}
