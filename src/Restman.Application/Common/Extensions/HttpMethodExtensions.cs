using System.Reflection;

namespace Restman.Application.Common.Extensions;

public static class HttpMethodExtensions
{
    public static string[] GetAllHttpMethods()
    {
        var methods = typeof(HttpMethod)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(property => property.PropertyType == typeof(HttpMethod))
            .Select(property => ((HttpMethod)property.GetValue(null)!).Method)
            .ToArray();

        return methods;
    }
}
