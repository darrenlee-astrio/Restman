using Restman.Winform.Common.Models;

namespace Restman.Winform.Common.Extensions;

public static class KeyValueTwinWithEnableExtensions
{
    public static Dictionary<string, string> GetDictionary(this List<KeyValueTwinWithEnable> list, bool onlyEnabledRows = true)
    {
        return list.Where(x => x.Enable == onlyEnabledRows)
                    .Select(x => new KeyValuePair<string, string>(x.Key, x.Value))
                    .ToDictionary();
    }

    public static List<KeyValueTwinWithEnable> Combine(this List<KeyValueTwinWithEnable> source, List<KeyValueTwinWithEnable> other)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (other == null) throw new ArgumentNullException("other");

        var combinedList = new List<KeyValueTwinWithEnable>(source);

        foreach (var item in other)
        {
            var index = combinedList.FindIndex(x => x.Key == item.Key);

            if (index < 0)
            {
                combinedList.Add(item);
            }
            else if (index > 0 && item.Enable)
            {
                combinedList[index] = item;
            }
        }
        return combinedList;
    }
}
