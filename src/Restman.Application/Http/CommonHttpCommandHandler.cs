using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Restman.Application.Common;
using Restman.Application.Common.Constants;
using Restman.Application.Common.Extensions;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Restman.Application.Http;

public class CommonHttpCommandHandler : IRequestHandler<CommonHttpCommand, ErrorOr<CommonHttpResponse>>
{
    private readonly HttpClient _httpClient;

    public CommonHttpCommandHandler(
        ILogger<CommonHttpCommandHandler> logger,
        IHttpClientFactory httpClientFactory)
    {
        // Should not dispose http client since it is retrieved via a DI container
        // Let the container handle disposal
        _httpClient = httpClientFactory.CreateClient(nameof(Application));
    }

    public async Task<ErrorOr<CommonHttpResponse>> Handle(CommonHttpCommand request, CancellationToken cancellationToken)
    {
        var response = new CommonHttpResponse();

        using (var httpRequest = new HttpRequestMessage(HttpMethod.Parse(request.Method), request.Url))
        {
            if (!string.IsNullOrEmpty(request.ServerSslHashString))
            {
                httpRequest.Headers.Add(DataHolder.ExpectedServerCertHashHeaderName, request.ServerSslHashString);
            }

            foreach (var kvp in request.Headers)
            {
                httpRequest.Headers.Add(kvp.Key, kvp.Value);
            }

            httpRequest.Content = request.Content;

            (HttpResponseMessage httpResponse, TimeSpan elapsedTime) = await _httpClient.SendTimedAsync(httpRequest, cancellationToken);

            response.StatusCode = httpResponse.StatusCode;
            response.Headers = httpResponse.Headers;
            response.Content = await httpResponse.Content.ReadAsStringAsync();
            response.ElapsedTime = elapsedTime;

            return response;
        }
    }
}