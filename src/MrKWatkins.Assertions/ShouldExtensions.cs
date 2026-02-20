using System.Numerics;
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
    /// Begins a fluent assertion on the specified boolean value.
    /// </summary>
    /// <param name="value">The boolean value to assert on.</param>
    /// <returns>A <see cref="BooleanAssertions" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(1)]
    public static BooleanAssertions Should(this bool value) => new(value);

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

    /// <summary>
    /// Begins a fluent assertion on the specified async action.
    /// </summary>
    /// <param name="value">The async action to assert on.</param>
    /// <returns>An <see cref="AsyncActionAssertions" /> for the async action.</returns>
    [Pure]
    public static AsyncActionAssertions Should([InstantHandle] this Func<Task> value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified byte value.
    /// </summary>
    /// <param name="value">The byte value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<byte> Should(this byte value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified sbyte value.
    /// </summary>
    /// <param name="value">The sbyte value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<sbyte> Should(this sbyte value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified short value.
    /// </summary>
    /// <param name="value">The short value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<short> Should(this short value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified ushort value.
    /// </summary>
    /// <param name="value">The ushort value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<ushort> Should(this ushort value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified int value.
    /// </summary>
    /// <param name="value">The int value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<int> Should(this int value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified uint value.
    /// </summary>
    /// <param name="value">The uint value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<uint> Should(this uint value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified long value.
    /// </summary>
    /// <param name="value">The long value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<long> Should(this long value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified ulong value.
    /// </summary>
    /// <param name="value">The ulong value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<ulong> Should(this ulong value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified nint value.
    /// </summary>
    /// <param name="value">The nint value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<nint> Should(this nint value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified nuint value.
    /// </summary>
    /// <param name="value">The nuint value to assert on.</param>
    /// <returns>An <see cref="IntegerAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static IntegerAssertions<nuint> Should(this nuint value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified float value.
    /// </summary>
    /// <param name="value">The float value to assert on.</param>
    /// <returns>A <see cref="FloatingPointAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static FloatingPointAssertions<float> Should(this float value) => new(value);

    /// <summary>
    /// Begins a fluent assertion on the specified double value.
    /// </summary>
    /// <param name="value">The double value to assert on.</param>
    /// <returns>A <see cref="FloatingPointAssertions{T}" /> for the value.</returns>
    [Pure]
    [OverloadResolutionPriority(10)]
    public static FloatingPointAssertions<double> Should(this double value) => new(value);
}