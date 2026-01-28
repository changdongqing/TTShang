using Riok.Mapperly.Abstractions;
using Volo.Abp.Identity;
using Volo.Abp.Mapperly;

namespace TTShang.IdentityManagement.Blazor;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[MapExtraProperties]
public partial class IdentityUserBlazorMapper : MapperBase<IdentityUserDto, IdentityUserUpdateDto>
{
    [MapperIgnoreTarget(nameof(IdentityUserUpdateDto.Password))]
    [MapperIgnoreTarget(nameof(IdentityUserUpdateDto.RoleNames))]
    public override partial IdentityUserUpdateDto Map(IdentityUserDto source);

    [MapperIgnoreTarget(nameof(IdentityUserUpdateDto.Password))]
    [MapperIgnoreTarget(nameof(IdentityUserUpdateDto.RoleNames))]
    public override partial void Map(IdentityUserDto source, IdentityUserUpdateDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[MapExtraProperties]
public partial class IdentityRoleBlazorMapper : MapperBase<IdentityRoleDto, IdentityRoleUpdateDto>
{
    public override partial IdentityRoleUpdateDto Map(IdentityRoleDto source);

    public override partial void Map(IdentityRoleDto source, IdentityRoleUpdateDto destination);
}
