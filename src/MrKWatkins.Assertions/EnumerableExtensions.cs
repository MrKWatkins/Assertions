using System.Collections;

namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide non-generic enumerable assertions.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Asserts that the non-generic enumerable is sequence equal to the expected elements.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The expected elements.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> SequenceEqual<T>(this ObjectAssertions<T> assertions, [InstantHandle] params IEnumerable<object> expected)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        assertions.Value.OfType<object>().Should().SequenceEqual(expected);

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the non-generic enumerable is not sequence equal to the expected elements.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The elements the enumerable should not be sequence equal to.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> NotSequenceEqual<T>(this ObjectAssertions<T> assertions, [InstantHandle] params IEnumerable<object> expected)
        where T : IEnumerable
    {
        assertions.NotBeNull();

        assertions.Value.OfType<object>().Should().NotSequenceEqual(expected);

        return new ObjectAssertionsChain<T>(assertions);
    }
}