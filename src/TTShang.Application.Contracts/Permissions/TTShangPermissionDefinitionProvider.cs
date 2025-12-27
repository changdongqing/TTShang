using TTShang.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace TTShang.Permissions;

public class TTShangPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TTShangPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(TTShangPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(TTShangPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(TTShangPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(TTShangPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TTShangPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TTShangResource>(name);
    }
}
