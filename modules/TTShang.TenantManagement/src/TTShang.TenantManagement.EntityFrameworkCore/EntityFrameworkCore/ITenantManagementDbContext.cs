using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.TenantManagement.EntityFrameworkCore;

[ConnectionStringName(TenantManagementDbProperties.ConnectionStringName)]
public interface ITenantManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
