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

    /// <summary>
    /// Asserts that the floating-point value is zero.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeZero()
    {
        Verify.That(T.IsZero(Value), $"Value should be zero but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is not zero.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> NotBeZero()
    {
        Verify.That(!T.IsZero(Value), "Value should not be zero.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is negative.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeNegative()
    {
        Verify.That(T.IsNegative(Value), $"Value should be negative but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is not negative.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> NotBeNegative()
    {
        Verify.That(!T.IsNegative(Value), $"Value should not be negative but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is positive.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BePositive()
    {
        Verify.That(T.IsPositive(Value), $"Value should be positive but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is not positive.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> NotBePositive()
    {
        Verify.That(!T.IsPositive(Value), $"Value should not be positive but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is <see cref="double.NaN" /> (not a number).
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeNaN()
    {
        Verify.That(T.IsNaN(Value), $"Value should be NaN but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is not <see cref="double.NaN" /> (not a number).
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> NotBeNaN()
    {
        Verify.That(!T.IsNaN(Value), "Value should not be NaN.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is positive or negative infinity.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeInfinity()
    {
        Verify.That(T.IsInfinity(Value), $"Value should be infinity but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is not positive or negative infinity.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> NotBeInfinity()
    {
        Verify.That(!T.IsInfinity(Value), "Value should not be infinity.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is positive infinity.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BePositiveInfinity()
    {
        Verify.That(T.IsPositiveInfinity(Value), $"Value should be positive infinity but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the floating-point value is negative infinity.
    /// </summary>
    /// <returns>A <see cref="FloatingPointAssertionsChain{T}" /> for chaining further assertions.</returns>
    public FloatingPointAssertionsChain<T> BeNegativeInfinity()
    {
        Verify.That(T.IsNegativeInfinity(Value), $"Value should be negative infinity but was {Value}.");

        return new FloatingPointAssertionsChain<T>(this);
    }
}