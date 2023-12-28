using System.Reflection;

namespace Restman.Application.Common.Equality;

public static class EqualityHelper
{
    public static bool AreEqual<T>(T? obj1, T? obj2) where T : class, IEqualityComparable
    {
        if (ReferenceEquals(obj1, obj2))
            return true;

        if (obj1 == null || obj2 == null)
            return false;

        PropertyInfo[] properties = typeof(T).GetProperties();

        return properties.All(property =>
        {
            object? value1 = property.GetValue(obj1);
            object? value2 = property.GetValue(obj2);

            return EqualityComparer<object?>.Default.Equals(value1, value2);
        });
    }

    public static int GetHashCode<T>(T obj) where T : class, IEqualityComparable
    {
        if (obj == null)
            return 0;

        int hash = 17;
        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            object? value = property.GetValue(obj);
            hash = hash * 23 + (value?.GetHashCode() ?? 0);
        }

        return hash;
    }
}
