using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restman.Application.Common.Helpers;

public static class JsonHelper
{
    public static string PrettifyJson(string? jsonString)
    {
        if (string.IsNullOrEmpty(jsonString))
        {
            return string.Empty;
        }

        if (IsJsonValid(jsonString) is false)
        {
            return jsonString;
        }

        JToken parsedJson = JToken.Parse(jsonString);

        string prettifiedJson = parsedJson.ToString(Formatting.Indented);

        return prettifiedJson;
    }

    public static bool IsJsonValid(string jsonString)
    {
        try
        {
            JsonConvert.DeserializeObject(jsonString);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}
