namespace MrKWatkins.Assertions;

public static class Extensions
{
    [Pure]
    public static bool TryGetCount<T>([NoEnumeration] this IEnumerable<T> enumerable, out int count)
    {
        switch (enumerable)
        {
            case ICollection<T> collection:
                count = collection.Count;
                return true;

            case IReadOnlyCollection<T> collection:
                count = collection.Count;
                return true;
        }

        count = 0;
        return false;
    }
}