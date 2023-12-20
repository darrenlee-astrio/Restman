namespace Restman.Application.Common.Helpers;

public static class HttpMethodHelper
{
    public static bool TryParse(string methodString, out HttpMethod? httpMethod)
    {
        if (string.IsNullOrWhiteSpace(methodString))
        {
            httpMethod = null;
            return false;
        }

        try
        {
            httpMethod = HttpMethod.Parse(methodString.ToUpper());
            return true;
        }
        catch
        {
            httpMethod = null;
            return false;
        }
    }
}
