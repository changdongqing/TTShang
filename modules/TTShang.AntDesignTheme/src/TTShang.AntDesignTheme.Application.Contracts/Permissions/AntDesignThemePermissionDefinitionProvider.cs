using TTShang.AntDesignTheme.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TTShang.AntDesignTheme.Permissions;

public class AntDesignThemePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AntDesignThemePermissions.GroupName, L("Permission:AntDesignTheme"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AntDesignThemeResource>(name);
    }
}
