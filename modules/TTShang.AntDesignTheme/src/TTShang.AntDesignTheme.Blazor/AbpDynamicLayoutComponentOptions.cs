using System;
using System.Collections.Generic;

namespace TTShang.AntDesignTheme.Blazor;

public class AbpDynamicLayoutComponentOptions
{
    /// <summary>
    /// Used to define components that renders in the layout
    /// </summary>
    public Dictionary<Type, IDictionary<string,object>?> Components { get; set; }

    public AbpDynamicLayoutComponentOptions()
    {
        Components = new Dictionary<Type, IDictionary<string, object>?>();
    }
}