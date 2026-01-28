namespace TTShang.IdentityManagement;

public static class IdentityManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "IdentityManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "IdentityManagement";
}
