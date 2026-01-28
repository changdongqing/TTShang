using Volo.Abp.Reflection;

namespace TTShang.FeatureManagement.Permissions;

public class FeatureManagementPermissions
{
    public const string GroupName = "FeatureManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FeatureManagementPermissions));
    }
}
