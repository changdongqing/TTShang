using TTShang.TenantManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TTShang.TenantManagement.Permissions;

public class TenantManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TenantManagementPermissions.GroupName, L("Permission:TenantManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TenantManagementResource>(name);
    }
}
