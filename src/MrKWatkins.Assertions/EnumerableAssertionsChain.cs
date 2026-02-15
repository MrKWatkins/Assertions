namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on an enumerable value after a successful assertion.
/// </summary>
/// <typeparam name="TEnumerable">The type of the enumerable being asserted on.</typeparam>
/// <typeparam name="T">The type of elements in the enumerable.</typeparam>
/// <param name="enumerableAssertions">The assertions object to chain from.</param>
public readonly struct EnumerableAssertionsChain<TEnumerable, T>(EnumerableAssertions<TEnumerable, T> enumerableAssertions)
    where TEnumerable : IEnumerable<T>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public EnumerableAssertions<TEnumerable, T> And { get; } = enumerableAssertions;

    /// <summary>
    /// Gets the enumerable value being asserted on.
    /// </summary>
    public TEnumerable Value => And.Value;
}