using AntDesign;
using Microsoft.AspNetCore.Components;
using Volo.Abp.UI.Navigation;

namespace TTShang.AntDesignTheme.Blazor.Themes.AntDesignTheme;

public partial class MainMenuItem : ComponentBase
{
    [Parameter]
    public ApplicationMenuItem Menu { get; set; }
}
