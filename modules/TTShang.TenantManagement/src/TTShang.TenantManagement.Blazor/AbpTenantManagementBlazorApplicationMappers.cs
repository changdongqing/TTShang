using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Volo.Abp.TenantManagement;

namespace TTShang.TenantManagement.Blazor;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[MapExtraProperties]
public partial class AbpTenantManagementBlazorMapper : MapperBase<TenantDto, TenantUpdateDto>
{
    public override partial TenantUpdateDto Map(TenantDto source);

    public override partial void Map(TenantDto source, TenantUpdateDto destination);
}
