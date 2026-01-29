using System;
using System.Collections.Generic;
using System.Linq;
using AntDesign.ProLayout;
using Volo.Abp.UI.Navigation;

namespace TTShang.AntDesignTheme.Blazor.Themes.AntDesignTheme;

public static class MenuDataItemConverter
{
    /// <summary>
    /// Converts ABP ApplicationMenu to ProLayout MenuDataItem array
    /// </summary>
    public static MenuDataItem[] ConvertToMenuDataItems(ApplicationMenu menu)
    {
        if (menu?.Items == null || !menu.Items.Any())
        {
            return Array.Empty<MenuDataItem>();
        }

        return menu.Items.Select(ConvertMenuItem).Where(x => x != null).ToArray()!;
    }

    /// <summary>
    /// Recursively converts ApplicationMenuItem to MenuDataItem
    /// </summary>
    private static MenuDataItem? ConvertMenuItem(ApplicationMenuItem menuItem)
    {
        if (menuItem == null)
        {
            return null;
        }

        var dataItem = new MenuDataItem
        {
            Name = menuItem.Name,
            Path = menuItem.Url?.TrimStart('/', '~'),
            Icon = menuItem.Icon,
            HideInMenu = false
        };

        // Recursively convert child items
        if (menuItem.Items != null && menuItem.Items.Any())
        {
            dataItem.Children = menuItem.Items
                .Select(ConvertMenuItem)
                .Where(x => x != null)
                .ToArray();
        }

        return dataItem;
    }
}
