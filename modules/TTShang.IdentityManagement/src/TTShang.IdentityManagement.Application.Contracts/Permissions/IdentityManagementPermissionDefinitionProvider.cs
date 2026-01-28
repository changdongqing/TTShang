using TTShang.IdentityManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TTShang.IdentityManagement.Permissions;

public class IdentityManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IdentityManagementPermissions.GroupName, L("Permission:IdentityManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IdentityManagementResource>(name);
    }
}
