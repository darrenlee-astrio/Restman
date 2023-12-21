using Restman.Winform.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Restman.Winform.Common.Extensions;

public static class HttpResponseHeadersExtensions
{
    public static List<KeyValueTwin> ToKeyValueTwin(this HttpResponseHeaders headers)
    {
        var list = new List<KeyValueTwin>();
        foreach (var header in headers)
        {
            list.Add(new KeyValueTwin { Key = header.Key, Value = string.Join(";", header.Value) });
        }
        return list;
    }
}
