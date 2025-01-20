namespace MrKWatkins.Assertions;

public static class ShouldExtensions
{
    [Pure]
    public static ObjectAssertions<T> Should<T>(this T? value)
        where T : notnull => new(value);

    [Pure]
    public static EnumerableAssertions<IEnumerable<T>, T> Should<T>([NoEnumeration] this IEnumerable<T> value) => new(value);

    [Pure]
    public static EnumerableAssertions<IReadOnlyCollection<T>, T> Should<T>([NoEnumeration] this IReadOnlyCollection<T> value) => new(value);

    [Pure]
    public static EnumerableAssertions<ICollection<T>, T> Should<T>([NoEnumeration] this ICollection<T> value) => new(value);

    [Pure]
    public static ReadOnlyListAssertions<IReadOnlyList<T>, T> Should<T>([NoEnumeration] this IReadOnlyList<T> value) => new(value);

    [Pure]
    public static EnumerableAssertions<IList<T>, T> Should<T>([NoEnumeration] this IList<T> value) => new(value);

    [Pure]
    public static ReadOnlyListAssertions<List<T>, T> Should<T>([NoEnumeration] this List<T> value) => new(value);

    [Pure]
    public static EnumerableAssertions<IReadOnlySet<T>, T> Should<T>([NoEnumeration] this IReadOnlySet<T> value) => new(value);

    [Pure]
    public static EnumerableAssertions<ISet<T>, T> Should<T>([NoEnumeration] this ISet<T> value) => new(value);

    [Pure]
    public static EnumerableAssertions<HashSet<T>, T> Should<T>([NoEnumeration] this HashSet<T> value) => new(value);

    [Pure]
    public static ReadOnlyDictionaryAssertions<IReadOnlyDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NoEnumeration] this IReadOnlyDictionary<TKey, TValue> value) => new(value);

    [Pure]
    public static ReadOnlyDictionaryAssertions<Dictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NoEnumeration] this Dictionary<TKey, TValue> value)
        where TKey : notnull => new(value);

    [Pure]
    public static EnumerableAssertions<T[], T> Should<T>([NoEnumeration] this T[] value) => new(value);

    [Pure]
    public static ReadOnlySpanAssertions<T> Should<T>([NoEnumeration] this ReadOnlySpan<T> value) => new(value);

    [Pure]
    public static ActionAssertions Should(this Action value) => new(value);
}