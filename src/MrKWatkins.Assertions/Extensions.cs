using System.Collections;

namespace MrKWatkins.Assertions;

internal static class Extensions
{
    [Pure]
    internal static bool TryGetCount([NoEnumeration] this IEnumerable enumerable, out int count)
    {
        switch (enumerable)
        {
            case ICollection collection:
                count = collection.Count;
                return true;
        }

        count = 0;
        return false;
    }

    [Pure]
    internal static bool TryGetCount<T>([NoEnumeration] this IEnumerable<T> enumerable, out int count)
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