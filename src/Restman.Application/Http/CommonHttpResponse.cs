using System.Net;
using System.Net.Http.Headers;

namespace Restman.Application.Http;

public class CommonHttpResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public HttpResponseHeaders Headers { get; set; } = null!;
    public string? Content { get; set; }
    public TimeSpan ElapsedTime { get; set; }
}
