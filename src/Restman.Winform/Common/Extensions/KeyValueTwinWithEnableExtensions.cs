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
}
