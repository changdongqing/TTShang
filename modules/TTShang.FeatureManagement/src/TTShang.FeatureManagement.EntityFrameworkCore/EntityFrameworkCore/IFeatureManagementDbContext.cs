using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.FeatureManagement.EntityFrameworkCore;

[ConnectionStringName(FeatureManagementDbProperties.ConnectionStringName)]
public interface IFeatureManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
