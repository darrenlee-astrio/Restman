using ErrorOr;
using MediatR;
using Restman.Application.Common.Extensions;

namespace Restman.Application.HttpRequests.ExecuteHttpRequest.Queries;

internal partial class ExecuteHttpRequestQueryHandler : IRequestHandler<ExecuteHttpRequestQuery, ErrorOr<ExecuteHttpRequestQueryResponse>>
{
    private readonly HttpClient _httpClient;

    public ExecuteHttpRequestQueryHandler(IHttpClientFactory httpClientFactory)
    {
        // Should not dispose http client since it is retrieved via a DI container
        // Let the container handle disposal
        _httpClient = httpClientFactory.CreateClient(nameof(Application));
    }

    public async Task<ErrorOr<ExecuteHttpRequestQueryResponse>> Handle(ExecuteHttpRequestQuery request, CancellationToken cancellationToken)
    {
        // TODO: Log http request?
        // Use custom serilog sink to inject into LogForm?
        var response = new ExecuteHttpRequestQueryResponse();

        using (var httpRequest = new HttpRequestMessage(HttpMethod.Parse(request.Method), request.Url))
        {
            foreach (var kvp in request.Headers)
            {
                request.Headers.Add(kvp.Key, kvp.Value);
            }

            if (request.Content is not null)
            {
                httpRequest.Content = request.Content;
            }

            (HttpResponseMessage httpResponse, TimeSpan elapsedTime) = await _httpClient.SendTimedAsync(httpRequest, cancellationToken);

            response.StatusCode = httpResponse.StatusCode;
            response.Headers = httpResponse.Headers;
            response.Content = await httpResponse.Content.ReadAsStringAsync();
            response.ElapsedTime = elapsedTime;

            return response;

        }
    }
}
