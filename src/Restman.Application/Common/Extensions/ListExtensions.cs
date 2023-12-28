namespace Restman.Application.Common.Extensions;

public static class ListExtensions
{
    public static List<T> Combine<T>(this List<T> firstList, List<T> secondList)
    {
        if (firstList == null)
        {
            throw new ArgumentNullException(nameof(firstList));
        }

        if (secondList == null)
        {
            throw new ArgumentNullException(nameof(secondList));
        }

        return firstList.Concat(secondList).ToList();
    }
}
