using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.PermissionManagement.EntityFrameworkCore;

[ConnectionStringName(PermissionManagementDbProperties.ConnectionStringName)]
public interface IPermissionManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
