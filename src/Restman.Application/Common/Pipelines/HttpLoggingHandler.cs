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

        if (request.Content != null)
        {
            string requestBody = JsonHelper.PrettifyJson(await request.Content.ReadAsStringAsync());
            //_logger.LogInformation($"Request Body:\n {requestBody}");
        }

        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

        _logger.LogInformation($"{(int)response.StatusCode} {response.StatusCode}");

        if (response.Content != null)
        {
            string responseBody = JsonHelper.PrettifyJson(await response.Content.ReadAsStringAsync());
            //_logger.LogInformation($"Response Body:\n {responseBody}");
        }

        return response;
    }
}