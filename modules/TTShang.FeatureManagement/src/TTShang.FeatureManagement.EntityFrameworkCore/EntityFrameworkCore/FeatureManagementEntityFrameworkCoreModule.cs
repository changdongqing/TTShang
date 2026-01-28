using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TTShang.FeatureManagement.EntityFrameworkCore;

[DependsOn(
    typeof(FeatureManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class FeatureManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<FeatureManagementDbContext>(options =>
        {
            options.AddDefaultRepositories<IFeatureManagementDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
