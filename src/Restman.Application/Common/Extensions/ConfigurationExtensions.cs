using Microsoft.Extensions.Configuration;

namespace Restman.Application.Common.Extensions;

public static class ConfigurationExtensions
{
    public static T? GetConfigurationValue<T>(this IConfiguration configuration, string key)
    {
        string? value = configuration[key];

        if (value != null)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing configuration value for key '{key}': {ex.Message}");
            }
        }

        return default(T);
    }
}