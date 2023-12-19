using System.Diagnostics;

namespace Restman.Winform.Common.Extensions;

public static class HttpClientExtensions
{
    public static async Task<(HttpResponseMessage, TimeSpan)> SendTimedAsync(
        this HttpClient httpClient,
        HttpRequestMessage request)
    {
        Stopwatch sw = Stopwatch.StartNew();
        HttpResponseMessage response = await httpClient.SendAsync(request);
        sw.Stop();

        return (response, sw.Elapsed);
    }
}
