using System.Reflection;

namespace Restman.Winform.Common.Extensions;

public static class HttpMethodExtensions
{
    public static string[] GetAllHttpMethods()
    {
        // Use reflection to get all public static fields (HTTP methods) in the HttpMethod class
        var methods = typeof(HttpMethod)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(property => property.PropertyType == typeof(HttpMethod))
            .Select(property => ((HttpMethod)property.GetValue(null)!).Method)
            .ToArray();

        return methods;
    }
}
