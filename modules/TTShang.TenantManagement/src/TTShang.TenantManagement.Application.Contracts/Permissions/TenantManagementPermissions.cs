using Volo.Abp.Reflection;

namespace TTShang.TenantManagement.Permissions;

public class TenantManagementPermissions
{
    public const string GroupName = "TenantManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TenantManagementPermissions));
    }
}
