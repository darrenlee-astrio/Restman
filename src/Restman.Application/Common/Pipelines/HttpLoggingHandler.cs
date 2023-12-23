using Microsoft.Extensions.Logging;
using Restman.Application.Common.Helpers;

namespace Restman.Application.Common.Pipelines;

public class HttpLoggingHandler : DelegatingHandler
{
    private readonly ILogger<HttpLoggingHandler> _logger;

    public HttpLoggingHandler(ILogger<HttpLoggingHandler> logger)
    {
        _logger = logger;
    }
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{request.Method} {request.RequestUri}");

        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        _logger.LogInformation($"{(int)response.StatusCode} {response.StatusCode}");

        return response;
    }
}