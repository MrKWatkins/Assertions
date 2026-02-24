using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a floating-point value after a successful assertion.
/// </summary>
/// <typeparam name="T">The floating-point type of the value being asserted on.</typeparam>
/// <param name="floatingPointAssertions">The assertions object to chain from.</param>
public readonly struct FloatingPointAssertionsChain<T>(FloatingPointAssertions<T> floatingPointAssertions)
    where T : struct, IFloatingPoint<T>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public FloatingPointAssertions<T> And { get; } = floatingPointAssertions;

    /// <summary>
    /// Gets the floating-point value being asserted on.
    /// </summary>
    public T Value => And.Value;
}