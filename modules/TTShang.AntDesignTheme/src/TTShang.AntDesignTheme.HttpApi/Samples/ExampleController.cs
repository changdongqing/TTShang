using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace TTShang.AntDesignTheme.Samples;

[Area(AntDesignThemeRemoteServiceConsts.ModuleName)]
[RemoteService(Name = AntDesignThemeRemoteServiceConsts.RemoteServiceName)]
[Route("api/ant-design-theme/example")]
public class ExampleController : AntDesignThemeController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public ExampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}
