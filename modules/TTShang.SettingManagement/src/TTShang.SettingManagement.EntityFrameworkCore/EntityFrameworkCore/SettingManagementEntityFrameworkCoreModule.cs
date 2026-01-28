using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TTShang.SettingManagement.EntityFrameworkCore;

[DependsOn(
    typeof(SettingManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SettingManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SettingManagementDbContext>(options =>
        {
            options.AddDefaultRepositories<ISettingManagementDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
