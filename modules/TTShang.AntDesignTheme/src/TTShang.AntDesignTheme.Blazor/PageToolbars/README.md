# PageToolbar 子类使用指南

本文档介绍如何使用新创建的两个 PageToolbar 子类。

## 1. CrudPageToolbar<TEntityDto, TKey>

用于行内编辑或网格（Grid）数据的增删改查场景的通用工具栏。

### 特性

- **默认按钮**: 增行 (AddRow)、删行 (DeleteRow)、保存 (Save)
- **泛型支持**: 支持指定实体 DTO 类型 `TEntityDto` 和主键类型 `TKey`
- **回调机制**: 通过 Func<Task> 回调属性实现自定义操作逻辑
- **灵活配置**: 可控制每个按钮的可见性、文本、图标、顺序和权限
- **危险样式**: 删行按钮默认使用红色危险样式

### 基本用法

```csharp
// 创建 CRUD 工具栏实例并设置回调
var toolbar = new CrudPageToolbar<MyEntityDto, Guid>();
toolbar.OnAddRow = async () => 
{
    // 添加新行的逻辑
    await AddNewRowAsync();
};

toolbar.OnDeleteRow = async () => 
{
    // 删除选中行的逻辑
    await DeleteSelectedRowsAsync();
};

toolbar.OnSave = async () => 
{
    // 保存更改的逻辑
    await SaveChangesAsync();
};

// 构建工具栏（必须调用以应用配置）
toolbar.Build();
```

### 高级用法

#### 使用流式 API 配置

```csharp
// 流式 API 会自动构建工具栏
var toolbar = new CrudPageToolbar<MyEntityDto, Guid>()
    .WithAddRowCallback(async () => await AddNewRowAsync())
    .WithDeleteRowCallback(async () => await DeleteSelectedRowsAsync())
    .WithSaveCallback(async () => await SaveChangesAsync())
    .ConfigureButtonVisibility(showDeleteRow: false); // 隐藏删除按钮
```

#### 自定义按钮属性

```csharp
var toolbar = new CrudPageToolbar<MyEntityDto, Guid>
{
    // 自定义按钮文本（支持本地化）
    AddRowButtonText = "添加",
    DeleteRowButtonText = "移除",
    SaveButtonText = "提交",
    
    // 自定义按钮图标
    AddRowIcon = "plus-circle",
    DeleteRowIcon = "delete",
    SaveIcon = "check",
    
    // 配置按钮顺序
    AddRowButtonOrder = 0,
    SaveButtonOrder = 1,
    DeleteRowButtonOrder = 2,
    
    // 配置权限要求
    AddRowRequiredPolicy = "MyApp.Create",
    DeleteRowRequiredPolicy = "MyApp.Delete",
    SaveRequiredPolicy = "MyApp.Update"
};

// 设置回调
toolbar.OnAddRow = async () => await AddNewRowAsync();
toolbar.OnDeleteRow = async () => await DeleteSelectedRowsAsync();
toolbar.OnSave = async () => await SaveChangesAsync();

// 构建工具栏（必须调用以应用配置）
toolbar.Build();
```

#### 动态更新工具栏

```csharp
// 修改属性后使用 Rebuild() 重新构建工具栏
toolbar.ShowDeleteRowButton = false;
toolbar.Rebuild(); // 重新构建工具栏
```

#### 添加自定义按钮

```csharp
// 在配置后添加自定义按钮
toolbar.AddButton(
    text: "复制",
    clicked: async () => await CopySelectedRowsAsync(),
    icon: "copy",
    color: ButtonType.Default,
    order: 10
);
```

## 2. BasicQueryToolbar

用于标准列表页面的基础查询工具栏，包含刷新和导出等辅助操作。

### 特性

- **默认按钮**: 刷新 (Refresh)、导出 (Export)
- **扩展方法**: 提供便捷方法快速添加高级搜索、打印等常用按钮
- **灵活配置**: 可控制每个按钮的可见性、文本、图标和顺序

### 基本用法

```csharp
// 创建查询工具栏实例并设置回调
var toolbar = new BasicQueryToolbar();
toolbar.OnRefresh = async () => 
{
    // 刷新数据的逻辑
    await RefreshDataAsync();
};

toolbar.OnExport = async () => 
{
    // 导出数据的逻辑
    await ExportDataAsync();
};

// 构建工具栏（必须调用以应用配置）
toolbar.Build();
```

### 高级用法

#### 使用流式 API 配置

```csharp
// 流式 API 会自动构建工具栏
var toolbar = new BasicQueryToolbar()
    .WithRefreshCallback(async () => await RefreshDataAsync())
    .WithExportCallback(async () => await ExportDataAsync());
```

#### 添加高级搜索按钮

```csharp
var toolbar = new BasicQueryToolbar()
    .WithRefreshCallback(async () => await RefreshDataAsync())
    .WithExportCallback(async () => await ExportDataAsync())
    .AddAdvancedSearchButton(
        clicked: async () => await ShowAdvancedSearchDialogAsync(),
        text: "高级搜索",  // 可选，有默认值
        icon: "search",    // 可选，有默认值
        order: 10          // 可选，有默认值
    );
```

#### 添加打印按钮

```csharp
toolbar.AddPrintButton(
    clicked: async () => await PrintCurrentPageAsync(),
    text: "打印",    // 可选，有默认值
    icon: "printer", // 可选，有默认值
    order: 11        // 可选，有默认值
);
```

#### 添加自定义按钮

```csharp
// 使用通用方法添加任意自定义按钮
toolbar.AddCustomButton(
    text: "批量操作",
    clicked: async () => await BatchOperationAsync(),
    icon: "edit",
    color: ButtonType.Primary,
    order: 20,
    requiredPolicyName: "MyApp.BatchOperation"
);
```

#### 自定义按钮属性

```csharp
var toolbar = new BasicQueryToolbar
{
    // 自定义按钮文本
    RefreshButtonText = "重新加载",
    ExportButtonText = "导出Excel",
    
    // 自定义按钮图标
    RefreshIcon = "sync",
    ExportIcon = "file-excel",
    
    // 配置按钮顺序
    RefreshButtonOrder = 0,
    ExportButtonOrder = 1,
    
    // 配置权限要求
    RefreshRequiredPolicy = null, // 无权限要求
    ExportRequiredPolicy = "MyApp.Export"
};

// 设置回调
toolbar.OnRefresh = async () => await RefreshDataAsync();
toolbar.OnExport = async () => await ExportDataAsync();

// 构建工具栏（必须调用以应用配置）
toolbar.Build();
```

#### 控制按钮可见性

```csharp
// 创建时配置按钮可见性
var toolbar = new BasicQueryToolbar()
    .WithRefreshCallback(async () => await RefreshDataAsync())
    .WithExportCallback(async () => await ExportDataAsync())
    .ConfigureButtonVisibility(showExport: false); // 隐藏导出按钮（会自动构建）
```

## 集成示例

### 在 Blazor 页面中使用

```razor
@page "/my-entities"
@inherits AbpComponentBase

<PageHeader Title="实体管理" Toolbar="@_toolbar" />

<DataGrid @ref="_dataGrid" />

@code {
    private CrudPageToolbar<MyEntityDto, Guid> _toolbar;
    private ITable _dataGrid;

    protected override async Task OnInitializedAsync()
    {
        // 初始化 CRUD 工具栏
        _toolbar = new CrudPageToolbar<MyEntityDto, Guid>()
            .WithAddRowCallback(async () => 
            {
                // 向数据网格添加新行
                await _dataGrid.AddRowAsync();
            })
            .WithDeleteRowCallback(async () => 
            {
                // 删除选中的行
                var selectedRows = _dataGrid.GetSelectedRows();
                await DeleteRowsAsync(selectedRows);
            })
            .WithSaveCallback(async () => 
            {
                // 保存所有更改
                await SaveAllChangesAsync();
            });
            
        await base.OnInitializedAsync();
    }
}
```

### 在查询页面中使用

```razor
@page "/my-query"
@inherits AbpComponentBase

<PageHeader Title="数据查询" Toolbar="@_toolbar" />

<Table DataSource="@_entities" />

@code {
    private BasicQueryToolbar _toolbar;
    private List<MyEntityDto> _entities;

    protected override async Task OnInitializedAsync()
    {
        // 初始化查询工具栏
        _toolbar = new BasicQueryToolbar()
            .WithRefreshCallback(async () => await LoadDataAsync())
            .WithExportCallback(async () => await ExportToExcelAsync())
            .AddAdvancedSearchButton(async () => await ShowSearchDialogAsync())
            .AddPrintButton(async () => await PrintReportAsync());
            
        await LoadDataAsync();
        await base.OnInitializedAsync();
    }
    
    private async Task LoadDataAsync()
    {
        _entities = await MyAppService.GetListAsync();
        StateHasChanged();
    }
}
```

## 注意事项

1. **泛型约束**: `CrudPageToolbar<TEntityDto, TKey>` 要求 `TEntityDto` 实现 `IEntityDto<TKey>` 接口（ABP 标准接口）。

2. **回调函数**: 所有回调函数都是可空的 `Func<Task>?`，如果未设置回调，按钮点击时不会执行任何操作。

3. **构建工具栏**: 
   - 使用流式 API（WithXxxCallback、ConfigureButtonVisibility等）时会自动构建工具栏。
   - 使用属性赋值方式配置时，需要手动调用 `Build()` 方法来应用配置。
   - 修改属性后可以调用 `Rebuild()` 方法重新构建工具栏。

4. **按钮顺序**: 按钮的显示顺序由 `Order` 属性决定，数值越小越靠前。

5. **权限控制**: 通过 `RequiredPolicy` 属性可以为按钮设置权限要求，只有拥有相应权限的用户才能看到该按钮。

6. **本地化**: 按钮文本默认为中文，可以自定义为其他语言。建议使用 ABP 的本地化机制来提供多语言支持。

7. **Danger 样式**: `CrudPageToolbar` 的删除按钮默认使用红色危险样式（`danger: true`），以提醒用户这是危险操作。
