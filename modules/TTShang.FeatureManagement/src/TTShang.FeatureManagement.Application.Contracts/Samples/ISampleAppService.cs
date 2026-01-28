using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TTShang.FeatureManagement.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
