using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.IdentityManagement.EntityFrameworkCore;

[ConnectionStringName(IdentityManagementDbProperties.ConnectionStringName)]
public interface IIdentityManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
