using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TTShang.AntDesignTheme.EntityFrameworkCore;

[DependsOn(
    typeof(AntDesignThemeDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class AntDesignThemeEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AntDesignThemeDbContext>(options =>
        {
            options.AddDefaultRepositories<IAntDesignThemeDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
