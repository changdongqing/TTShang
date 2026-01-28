using TTShang.SettingManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TTShang.SettingManagement.Permissions;

public class SettingManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SettingManagementPermissions.GroupName, L("Permission:SettingManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SettingManagementResource>(name);
    }
}
