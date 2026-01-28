using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TTShang.AntDesignTheme.EntityFrameworkCore;

[ConnectionStringName(AntDesignThemeDbProperties.ConnectionStringName)]
public class AntDesignThemeDbContext : AbpDbContext<AntDesignThemeDbContext>, IAntDesignThemeDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AntDesignThemeDbContext(DbContextOptions<AntDesignThemeDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAntDesignTheme();
    }
}
