using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Restman.Application.Common.Constants;
using Restman.Application.Common.Extensions;

namespace Restman.Application.Http;

public class CommonHttpCommandHandler : IRequestHandler<CommonHttpCommand, ErrorOr<CommonHttpResponse>>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CommonHttpCommandHandler(
        ILogger<CommonHttpCommandHandler> logger,
        IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ErrorOr<CommonHttpResponse>> Handle(CommonHttpCommand request, CancellationToken cancellationToken)
    {
        var namedClient = CollectionId.All.FirstOrDefault(x => x.Equals(request.CollectionId, StringComparison.OrdinalIgnoreCase));

        var httpClient = !string.IsNullOrEmpty(namedClient) ?
            _httpClientFactory.CreateClient(namedClient) :
            _httpClientFactory.CreateClient(DataHolder.DefaultHttpClient);

        var response = new CommonHttpResponse();

        using (var httpRequest = new HttpRequestMessage(HttpMethod.Parse(request.Method), request.Url))
        {
            foreach (var kvp in request.Headers)
            {
                httpRequest.Headers.Add(kvp.Key, kvp.Value);
            }

            httpRequest.Content = request.Content;

            (HttpResponseMessage httpResponse, TimeSpan elapsedTime) = await httpClient.SendTimedAsync(httpRequest, cancellationToken);

            response.StatusCode = httpResponse.StatusCode;
            response.Headers = httpResponse.Headers;
            response.Content = await httpResponse.Content.ReadAsStringAsync();
            response.ElapsedTime = elapsedTime;

            return response;
        }
    }
}