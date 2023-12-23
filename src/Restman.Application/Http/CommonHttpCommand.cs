using ErrorOr;
using MediatR;

namespace Restman.Application.Http;

public record CommonHttpCommand : IRequest<ErrorOr<CommonHttpResponse>>
{
    public string Url { get; set; } = null!;
    public string Method { get; set; } = null!;
    public Dictionary<string, string> Headers { get; set; } = new();
    public HttpContent? Content { get; set; }
    public string? ServerSslHashString { get; set; }

    public CommonHttpCommand(
        string url,
        string method,
        Dictionary<string, string> headers,
        HttpContent? content,
        string? serverSslHashString)
    {
        Url = url;
        Method = method;
        Headers = headers;
        Content = content;
        ServerSslHashString = serverSslHashString;
    }
}