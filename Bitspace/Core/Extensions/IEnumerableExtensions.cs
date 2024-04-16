namespace Bitspace.Core;

public static class IEnumerableExtensions
{
    public static IEnumerable<T> GetDistinctElements<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.Select(x => x).Distinct();
    }
}