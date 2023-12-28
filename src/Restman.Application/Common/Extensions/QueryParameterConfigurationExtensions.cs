using Restman.Application.Common.Models.AppData.Configuration;

namespace Restman.Application.Common.Extensions;

public static class QueryParameterConfigurationExtensions
{
    public static Dictionary<string, string> GetDictionary(this List<QueryParameterConfiguration> configurations, bool omitDisabled = true)
    {
        if (configurations == null)
        {
            throw new ArgumentNullException(nameof(configurations));
        }

        var dictionary = new Dictionary<string, string>();

        foreach (var configuration in configurations)
        {
            if (omitDisabled && configuration.Enable is false)
            {
                continue;
            }

            dictionary[configuration.Key] = configuration.Value;
        }

        return dictionary;
    }
}
