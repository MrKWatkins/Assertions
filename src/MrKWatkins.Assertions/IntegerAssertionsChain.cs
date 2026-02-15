using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on an integer value after a successful assertion.
/// </summary>
/// <typeparam name="T">The integer type of the value being asserted on.</typeparam>
/// <param name="integerAssertions">The assertions object to chain from.</param>
public readonly struct IntegerAssertionsChain<T>(IntegerAssertions<T> integerAssertions)
    where T : struct, IBinaryInteger<T>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public IntegerAssertions<T> And { get; } = integerAssertions;

    /// <summary>
    /// Gets the integer value being asserted on.
    /// </summary>
    public T Value => And.Value;
}
