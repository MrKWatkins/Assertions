namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a boolean value after a successful assertion.
/// </summary>
/// <param name="booleanAssertions">The assertions object to chain from.</param>
public readonly struct BooleanAssertionsChain(BooleanAssertions booleanAssertions)
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public BooleanAssertions And { get; } = booleanAssertions;

    /// <summary>
    /// Gets the boolean value being asserted on.
    /// </summary>
    public bool Value => And.Value;
}