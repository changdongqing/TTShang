using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.FeatureManagement.EntityFrameworkCore;

[ConnectionStringName(FeatureManagementDbProperties.ConnectionStringName)]
public class FeatureManagementDbContext : AbpDbContext<FeatureManagementDbContext>, IFeatureManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public FeatureManagementDbContext(DbContextOptions<FeatureManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureFeatureManagement();
    }
}
