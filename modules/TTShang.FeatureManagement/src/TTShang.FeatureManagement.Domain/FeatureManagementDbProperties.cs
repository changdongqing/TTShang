namespace TTShang.FeatureManagement;

public static class FeatureManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "FeatureManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "FeatureManagement";
}
