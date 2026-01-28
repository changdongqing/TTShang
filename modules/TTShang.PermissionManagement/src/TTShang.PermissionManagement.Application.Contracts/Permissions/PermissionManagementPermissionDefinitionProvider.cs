using TTShang.PermissionManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TTShang.PermissionManagement.Permissions;

public class PermissionManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PermissionManagementPermissions.GroupName, L("Permission:PermissionManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PermissionManagementResource>(name);
    }
}
