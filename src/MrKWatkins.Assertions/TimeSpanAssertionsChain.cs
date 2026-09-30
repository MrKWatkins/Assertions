namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a <see cref="TimeSpan" /> value after a successful assertion.
/// </summary>
/// <param name="timeSpanAssertions">The assertions object to chain from.</param>
public readonly struct TimeSpanAssertionsChain(TimeSpanAssertions timeSpanAssertions)
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public TimeSpanAssertions And { get; } = timeSpanAssertions;

    /// <summary>
    /// Gets the <see cref="TimeSpan" /> value being asserted on.
    /// </summary>
    public TimeSpan Value => And.Value;
}