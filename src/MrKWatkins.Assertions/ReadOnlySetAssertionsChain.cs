namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a read-only set value after a successful assertion.
/// </summary>
/// <typeparam name="TSet">The type of the set being asserted on.</typeparam>
/// <typeparam name="T">The type of elements in the set.</typeparam>
/// <param name="assertions">The assertions object to chain from.</param>
public readonly struct ReadOnlySetAssertionsChain<TSet, T>(ReadOnlySetAssertions<TSet, T> assertions)
    where TSet : IReadOnlySet<T>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public ReadOnlySetAssertions<TSet, T> And { get; } = assertions;

    /// <summary>
    /// Gets the set value being asserted on.
    /// </summary>
    public TSet Value => And.Value;
}
