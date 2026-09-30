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
    /// <typeparam name="TAssertions">The type of the assertions object.</typeparam>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The expected elements.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public static AssertionsChain<TAssertions, T> SequenceEqual<TAssertions, T>(this ObjectAssertions<TAssertions, T> assertions, [InstantHandle] params IEnumerable<object> expected)
        where TAssertions : ObjectAssertions<TAssertions, T>
        where T : IEnumerable
    {
        assertions.NotBeNull();

        assertions.Value.OfType<object>().Should().SequenceEqual(expected);

        return assertions.Chain();
    }

    /// <summary>
    /// Asserts that the non-generic enumerable is not sequence equal to the expected elements.
    /// </summary>
    /// <typeparam name="TAssertions">The type of the assertions object.</typeparam>
    /// <typeparam name="T">The type of the enumerable.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The elements the enumerable should not be sequence equal to.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public static AssertionsChain<TAssertions, T> NotSequenceEqual<TAssertions, T>(this ObjectAssertions<TAssertions, T> assertions, [InstantHandle] params IEnumerable<object> expected)
        where TAssertions : ObjectAssertions<TAssertions, T>
        where T : IEnumerable
    {
        assertions.NotBeNull();

        assertions.Value.OfType<object>().Should().NotSequenceEqual(expected);

        return assertions.Chain();
    }
}