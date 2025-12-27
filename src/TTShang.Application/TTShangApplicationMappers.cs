using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using TTShang.Books;

namespace TTShang;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class TTShangBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class TTShangCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}
