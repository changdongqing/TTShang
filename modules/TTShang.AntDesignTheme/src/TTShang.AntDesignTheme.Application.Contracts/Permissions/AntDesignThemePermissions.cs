using Volo.Abp.Reflection;

namespace TTShang.AntDesignTheme.Permissions;

public class AntDesignThemePermissions
{
    public const string GroupName = "AntDesignTheme";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AntDesignThemePermissions));
    }
}
