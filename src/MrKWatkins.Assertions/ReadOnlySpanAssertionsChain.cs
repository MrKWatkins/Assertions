namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a read-only span value after a successful assertion.
/// </summary>
/// <typeparam name="TItem">The type of elements in the span.</typeparam>
/// <param name="assertions">The assertions object to chain from.</param>
public readonly ref struct ReadOnlySpanAssertionsChain<TItem>(ReadOnlySpanAssertions<TItem> assertions)
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public ReadOnlySpanAssertions<TItem> And { get; } = assertions;

    /// <summary>
    /// Gets the span value being asserted on.
    /// </summary>
    public ReadOnlySpan<TItem> Value => And.Value;
}