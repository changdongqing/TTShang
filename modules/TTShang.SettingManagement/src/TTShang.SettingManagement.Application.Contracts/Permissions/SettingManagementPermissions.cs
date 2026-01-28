using Volo.Abp.Reflection;

namespace TTShang.SettingManagement.Permissions;

public class SettingManagementPermissions
{
    public const string GroupName = "SettingManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SettingManagementPermissions));
    }
}
