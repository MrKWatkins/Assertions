using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for floating-point values.
/// </summary>
/// <typeparam name="T">The floating-point type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
public sealed class FloatingPointAssertions<T>(T value) : ObjectAssertions<T>(value)
    where T : struct, IFloatingPoint<T>
{
    /// <summary>
    /// Asserts that the floating-point value is approximately equal to the expected value within the specified precision.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="precision">The maximum allowed difference between the value and the expected value.</param>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeApproximately(T expected, T precision)
    {
        Verify.That(T.Abs(Value - expected) <= precision, $"Value should be approximately {expected} (±{precision}) but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is less than the expected value.
    /// </summary>
    /// <param name="expected">The value the floating-point number should be less than.</param>
    /// <param name="precision">The precision to use for the comparison.</param>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeLessThan(T expected, T precision)
    {
        Verify.That(Value < expected - precision, $"Value should be less than {expected} (±{precision}) but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is less than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the floating-point number should be less than or equal to.</param>
    /// <param name="precision">The precision to use for the comparison.</param>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeLessThanOrEqualTo(T expected, T precision)
    {
        Verify.That(Value <= expected + precision, $"Value should be less than or equal to {expected} (±{precision}) but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is greater than the expected value.
    /// </summary>
    /// <param name="expected">The value the floating-point number should be greater than.</param>
    /// <param name="precision">The precision to use for the comparison.</param>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeGreaterThan(T expected, T precision)
    {
        Verify.That(Value > expected + precision, $"Value should be greater than {expected} (±{precision}) but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is greater than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the floating-point number should be greater than or equal to.</param>
    /// <param name="precision">The precision to use for the comparison.</param>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeGreaterThanOrEqualTo(T expected, T precision)
    {
        Verify.That(Value >= expected - precision, $"Value should be greater than or equal to {expected} (±{precision}) but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }
}
