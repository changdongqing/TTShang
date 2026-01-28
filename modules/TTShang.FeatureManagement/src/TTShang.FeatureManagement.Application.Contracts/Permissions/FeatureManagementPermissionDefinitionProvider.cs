using TTShang.FeatureManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TTShang.FeatureManagement.Permissions;

public class FeatureManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FeatureManagementPermissions.GroupName, L("Permission:FeatureManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FeatureManagementResource>(name);
    }
}
