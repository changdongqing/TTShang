using Volo.Abp.Reflection;

namespace TTShang.IdentityManagement.Permissions;

public class IdentityManagementPermissions
{
    public const string GroupName = "IdentityManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdentityManagementPermissions));
    }
}
