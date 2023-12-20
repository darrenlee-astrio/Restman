using System.Diagnostics;

namespace Restman.Application.Common.Extensions;

public static class HttpClientExtensions
{
    public static async Task<(HttpResponseMessage, TimeSpan)> SendTimedAsync(
        this HttpClient httpClient,
        HttpRequestMessage request,
        CancellationToken cancellationToken = default)
    {
        Stopwatch sw = Stopwatch.StartNew();
        HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken);
        sw.Stop();

        return (response, sw.Elapsed);
    }
}
