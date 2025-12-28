using AntDesign;
using Volo.Abp.Settings;

namespace TTShang.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;

public class AntDesignSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(AntDesignSettingNames.MenuPlacement, MenuPlacement.Left.ToString()),
            new SettingDefinition(AntDesignSettingNames.MenuTheme, MenuTheme.Dark.ToString())
        );
    }
}
