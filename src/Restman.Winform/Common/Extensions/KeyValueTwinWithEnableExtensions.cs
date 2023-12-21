using Restman.Winform.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
