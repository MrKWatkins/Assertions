namespace MrKWatkins.Assertions;

public static class Extensions
{
    [Pure]
    public static Assertions<T> Should<T>(this T value) where T : allows ref struct => new(value);

    [Pure]
    public static EnumerableAssertions<T> Should<T>([NoEnumeration] this IEnumerable<T> value) => new(value);

    [Pure]
    public static ReadOnlySpanAssertions<T> Should<T>([NoEnumeration] this ReadOnlySpan<T> value) => new(value);
}