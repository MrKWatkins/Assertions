namespace MrKWatkins.Assertions;

public static class ShouldExtensions
{
    [Pure]
    public static ObjectAssertions<T> Should<T>(this T? value) => new(value);

    [Pure]
    public static ReadOnlyDictionaryAssertions<IReadOnlyDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NoEnumeration] this IReadOnlyDictionary<TKey, TValue> value) => new(value);

    [Pure]
    public static ReadOnlyDictionaryAssertions<Dictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NoEnumeration] this Dictionary<TKey, TValue> value)
        where TKey : notnull => new(value);

    [Pure]
    public static ReadOnlySpanAssertions<T> Should<T>([NoEnumeration] this ReadOnlySpan<T> value) => new(value);

    [Pure]
    public static ActionAssertions Should(this Action value) => new(value);
}