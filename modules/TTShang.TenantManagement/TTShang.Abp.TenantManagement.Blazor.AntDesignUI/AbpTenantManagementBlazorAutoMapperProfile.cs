using AutoMapper;
using Volo.Abp.TenantManagement;

namespace TTShang.Abp.TenantManagement.Blazor.AntDesignUI;

public class AbpTenantManagementBlazorAutoMapperProfile : Profile
{
    public AbpTenantManagementBlazorAutoMapperProfile()
    {
        CreateMap<TenantDto, TenantUpdateDto>()
            .MapExtraProperties();
    }
}
