using System;

namespace TTShang.AntDesignTheme.Blazor.Components;

public interface ISingleTableEditableRow<TCreateDto, TUpdateDto, TKey>
{
    TKey Id { get; set; }
    bool IsNew { get; set; }
    bool IsModified { get; set; }
    bool IsDeleted { get; set; }

    TCreateDto ToCreateDto();
    TUpdateDto ToUpdateDto();
}
