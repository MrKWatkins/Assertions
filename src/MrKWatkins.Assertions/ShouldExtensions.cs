using System.Runtime.CompilerServices;

namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide the primary entry point for fluent assertions via <c>.Should()</c>.
/// </summary>
public static class ShouldExtensions
{
    /// <summary>
    /// Begins a fluent assertion on the specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to assert on.</param>
    /// <returns>An <see cref="ObjectAssertions{T}" /> for the value.</returns>
    [Pure]
    public static ObjectAssertions<T> Should<T>(this T? value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified string value.
    /// </summary>
    /// <param name="value">The string value to assert on.</param>
    /// <returns>A <see cref="StringAssertions" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(1)]
    public static StringAssertions Should(this string? value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified exception.
    /// </summary>
    /// <param name="value">The exception to assert on.</param>
    /// <returns>An <see cref="ExceptionAssertions{T}" /> for the exception.</returns>
    [Pure]
    [OverloadResolutionPriority(1)]
    public static ExceptionAssertions<Exception> Should(this Exception? value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="value">The exception to assert on.</param>
    /// <returns>An <see cref="ExceptionAssertions{T}" /> for the exception.</returns>
    [Pure]
    [OverloadResolutionPriority(2)]
    public static ExceptionAssertions<ArgumentException> Should(this ArgumentException? value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="value">The exception to assert on.</param>
    /// <returns>An <see cref="ExceptionAssertions{T}" /> for the exception.</returns>
    [Pure]
    [OverloadResolutionPriority(3)]
    public static ExceptionAssertions<ArgumentOutOfRangeException> Should(this ArgumentOutOfRangeException? value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified enumerable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="value">The enumerable to assert on.</param>
    /// <returns>An <see cref="EnumerableAssertions{TEnumerable, T}" /> for the enumerable.</returns>
    [Pure]
    [OverloadResolutionPriority(1)]
    public static EnumerableAssertions<IEnumerable<T>, T> Should<T>(this IEnumerable<T>? value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified read-only dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
    /// <typeparam name="TValue">The type of the dictionary values.</typeparam>
    /// <param name="value">The dictionary to assert on.</param>
    /// <returns>A <see cref="ReadOnlyDictionaryAssertions{TDictionary, TKey, TValue}" /> for the dictionary.</returns>
    [Pure]
    [OverloadResolutionPriority(2)]
    public static ReadOnlyDictionaryAssertions<IReadOnlyDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NoEnumeration] this IReadOnlyDictionary<TKey, TValue> value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
    /// <typeparam name="TValue">The type of the dictionary values.</typeparam>
    /// <param name="value">The dictionary to assert on.</param>
    /// <returns>A <see cref="ReadOnlyDictionaryAssertions{TDictionary, TKey, TValue}" /> for the dictionary.</returns>
    [Pure]
    [OverloadResolutionPriority(2)]
    public static ReadOnlyDictionaryAssertions<Dictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NoEnumeration] this Dictionary<TKey, TValue> value)
        where TKey : notnull => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified read-only span.
    /// </summary>
    /// <typeparam name="T">The type of elements in the span.</typeparam>
    /// <param name="value">The span to assert on.</param>
    /// <returns>A <see cref="ReadOnlySpanAssertions{T}" /> for the span.</returns>
    [Pure]
    public static ReadOnlySpanAssertions<T> Should<T>([NoEnumeration] this ReadOnlySpan<T> value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified action.
    /// </summary>
    /// <param name="value">The action to assert on.</param>
    /// <returns>An <see cref="ActionAssertions" /> for the action.</returns>
    [Pure]
    public static ActionAssertions Should([InstantHandle] this Action value) => new(value);
}