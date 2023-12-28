using Restman.Application.Common.Models.AppData.Configuration;
using System.Net.Http.Headers;

namespace Restman.Winform.Common.Extensions;

public static class HttpResponseHeadersExtensions
{
    public static List<KeyValueConfiguration> ToKeyValueConfigurations(this HttpResponseHeaders headers)
    {
        return headers.Select(x => new KeyValueConfiguration
        {
            Key = x.Key,
            Value = string.Join(';', x.Value)
        }).ToList();
    }
}
