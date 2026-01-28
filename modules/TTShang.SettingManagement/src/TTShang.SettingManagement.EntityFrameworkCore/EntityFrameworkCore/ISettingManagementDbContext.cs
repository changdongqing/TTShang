using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.SettingManagement.EntityFrameworkCore;

[ConnectionStringName(SettingManagementDbProperties.ConnectionStringName)]
public interface ISettingManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
