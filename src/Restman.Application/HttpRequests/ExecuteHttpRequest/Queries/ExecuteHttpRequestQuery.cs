using ErrorOr;
using MediatR;

namespace Restman.Application.HttpRequests.ExecuteHttpRequest.Queries;

public record ExecuteHttpRequestQuery : IRequest<ErrorOr<ExecuteHttpRequestQueryResponse>>
{
    public string Url { get; set; } = null!;
    public string Method { get; set; } = null!;
    public Dictionary<string, string> Headers { get; set; } = new();
    public StringContent? Content { get; set; }

    public ExecuteHttpRequestQuery(string url, string method, Dictionary<string, string> headers, StringContent? content)
    {
        Url = url;
        Method = method;
        Headers = headers;
        Content = content;
    }
}
