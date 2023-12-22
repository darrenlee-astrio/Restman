using Restman.Winform.Common.Models;
using System.Net.Http.Headers;

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
