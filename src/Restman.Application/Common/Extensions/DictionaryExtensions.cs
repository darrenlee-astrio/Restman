namespace Restman.Application.Common.Extensions;

public static class DictionaryExtensions
{
    public static Dictionary<TKey, TValue> Combine<TKey, TValue>(
        this Dictionary<TKey, TValue> source,
        Dictionary<TKey, TValue> other)
        where TKey : notnull
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (other == null)
            throw new ArgumentNullException(nameof(other));

        Dictionary<TKey, TValue> combinedDict = new Dictionary<TKey, TValue>(source);

        foreach (var kvp in other)
        {
            if (combinedDict.ContainsKey(kvp.Key))
            {
                combinedDict[kvp.Key] = kvp.Value;
            }
            else
            {
                combinedDict.Add(kvp.Key, kvp.Value);
            }
        }

        return combinedDict;
    }
}
