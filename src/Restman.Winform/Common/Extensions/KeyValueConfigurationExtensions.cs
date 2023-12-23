using Restman.Application.Common.Models.AppData;
using Restman.Winform.Common.Models;

namespace Restman.Winform.Common.Extensions;

public static class KeyValueConfigurationExtensions
{
    public static KeyValueTwinWithEnable? ToKeyValueTwinWithEnable(this KeyValueConfiguration item)
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

    public static List<KeyValueTwinWithEnable> ToKeyValueTwinsWithEnable(this List<KeyValueConfiguration> items)
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
