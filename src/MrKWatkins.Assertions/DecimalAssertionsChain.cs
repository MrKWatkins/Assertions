namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a <see cref="decimal" /> value after a successful assertion.
/// </summary>
/// <param name="decimalAssertions">The assertions object to chain from.</param>
public readonly struct DecimalAssertionsChain(DecimalAssertions decimalAssertions)
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public DecimalAssertions And { get; } = decimalAssertions;

    /// <summary>
    /// Gets the decimal value being asserted on.
    /// </summary>
    public decimal Value => And.Value;
}