namespace Restman.Application.Common.Helpers;

public static class UrlHelper
{
    public static bool IsValid(string urlString)
    {
        return Uri.TryCreate(urlString, UriKind.Absolute, out Uri? uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
