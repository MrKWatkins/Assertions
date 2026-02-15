namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a string value after a successful assertion.
/// </summary>
/// <param name="stringAssertions">The assertions object to chain from.</param>
public readonly struct StringAssertionsChain(StringAssertions stringAssertions)
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public StringAssertions And { get; } = stringAssertions;

    /// <summary>
    /// Gets the string value being asserted on.
    /// </summary>
    public string Value => And.Value;
}