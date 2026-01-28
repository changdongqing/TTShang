using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.PermissionManagement.EntityFrameworkCore;

[ConnectionStringName(PermissionManagementDbProperties.ConnectionStringName)]
public class PermissionManagementDbContext : AbpDbContext<PermissionManagementDbContext>, IPermissionManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public PermissionManagementDbContext(DbContextOptions<PermissionManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
    }
}
