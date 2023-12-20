namespace Restman.Winform.Common.Helpers;

public static class QueryStringHelper
{
    public static string Generate(Dictionary<string, string> dictionary)
    {
        if (dictionary.Count == 0)
        {
            return string.Empty;
        }

        string queryString = string.Join("&",
            dictionary.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

        return "?" + queryString;
    }
}
