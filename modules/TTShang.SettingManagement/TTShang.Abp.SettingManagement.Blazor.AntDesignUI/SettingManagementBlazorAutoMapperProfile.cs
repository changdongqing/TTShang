using AutoMapper;
using Volo.Abp.SettingManagement;

namespace TTShang.Abp.SettingManagement.Blazor.AntDesignUI;

public class SettingManagementBlazorAutoMapperProfile : Profile
{
    public SettingManagementBlazorAutoMapperProfile()
    {
        CreateMap<EmailSettingsDto, UpdateEmailSettingsDto>();
    }
}
