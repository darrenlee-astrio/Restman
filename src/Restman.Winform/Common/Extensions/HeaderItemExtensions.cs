using Restman.Application.Common.Models;
using Restman.Winform.Common.Models;

namespace Restman.Winform.Common.Extensions;

public static class HeaderItemExtensions
{
    public static KeyValueTwinWithEnable? ToKeyValueTwinWithEnable(this HeaderItem item)
    {
        if (item == null)
        {
            return null;
        }

        return new KeyValueTwinWithEnable
        {
            Enable = item.Enable,
            Key = item.Key,
            Value = item.Value
        };
    }

    public static List<KeyValueTwinWithEnable> ToKeyValueTwinsWithEnable(this List<HeaderItem> items)
    {
        var list = new List<KeyValueTwinWithEnable>();

        if (items == null)
        {
            return list;
        }

        foreach (var item in items)
        {
            if (item is not null)
            {
                list.Add(item.ToKeyValueTwinWithEnable()!);
            }
        }

        return list;
    }
}
