using Volo.Abp.Reflection;

namespace TTShang.PermissionManagement.Permissions;

public class PermissionManagementPermissions
{
    public const string GroupName = "PermissionManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PermissionManagementPermissions));
    }
}
