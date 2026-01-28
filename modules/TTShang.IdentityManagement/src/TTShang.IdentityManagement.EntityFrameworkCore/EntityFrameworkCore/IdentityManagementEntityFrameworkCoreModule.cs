using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TTShang.IdentityManagement.EntityFrameworkCore;

[DependsOn(
    typeof(IdentityManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class IdentityManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<IdentityManagementDbContext>(options =>
        {
            options.AddDefaultRepositories<IIdentityManagementDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
