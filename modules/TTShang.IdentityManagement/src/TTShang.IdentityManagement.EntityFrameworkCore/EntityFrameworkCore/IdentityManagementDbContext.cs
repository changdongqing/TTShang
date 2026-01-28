using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.IdentityManagement.EntityFrameworkCore;

[ConnectionStringName(IdentityManagementDbProperties.ConnectionStringName)]
public class IdentityManagementDbContext : AbpDbContext<IdentityManagementDbContext>, IIdentityManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public IdentityManagementDbContext(DbContextOptions<IdentityManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureIdentityManagement();
    }
}
