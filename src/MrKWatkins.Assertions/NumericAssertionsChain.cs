using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a numeric value after a successful assertion.
/// </summary>
/// <typeparam name="T">The numeric type of the value being asserted on.</typeparam>
/// <param name="numericAssertions">The assertions object to chain from.</param>
public readonly struct NumericAssertionsChain<T>(NumericAssertions<T> numericAssertions)
    where T : struct, INumberBase<T>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public NumericAssertions<T> And { get; } = numericAssertions;

    /// <summary>
    /// Gets the numeric value being asserted on.
    /// </summary>
    public T Value => And.Value;
}
