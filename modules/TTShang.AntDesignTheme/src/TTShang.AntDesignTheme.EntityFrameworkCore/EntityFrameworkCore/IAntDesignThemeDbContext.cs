using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.AntDesignTheme.EntityFrameworkCore;

[ConnectionStringName(AntDesignThemeDbProperties.ConnectionStringName)]
public interface IAntDesignThemeDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
