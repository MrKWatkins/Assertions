using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for numeric values.
/// </summary>
/// <typeparam name="T">The numeric type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
public sealed class NumericAssertions<T>(T value) : ObjectAssertions<T>(value)
    where T : struct, INumberBase<T>
{
    /// <summary>
    /// Asserts that the numeric value is equal to the expected value. Supports comparing numeric values of different types.
    /// </summary>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="expected">The expected value.</param>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// an <see cref="AssertionException"/> will be thrown with a descriptive message indicating the overflow.
    /// </remarks>
    public NumericAssertionsChain<T> Equal<TOther>(TOther expected)
        where TOther : struct, INumberBase<TOther>
    {
        T expectedAsT;
        try
        {
            expectedAsT = T.CreateChecked(expected);
        }
        catch (OverflowException)
        {
            Verify.That(false, $"Value should equal {expected} but the expected value cannot be represented as {typeof(T).Name} (overflow).");
            return default!; // Unreachable - Verify.That(false) always throws
        }

        Verify.That(EqualityComparer<T>.Default.Equals(Value, expectedAsT), $"Value should equal {expected} but was {Value}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is not equal to the expected value. Supports comparing numeric values of different types.
    /// </summary>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="expected">The value that is not expected.</param>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// the assertion succeeds because the value cannot equal something that cannot be represented in its type.
    /// </remarks>
    public NumericAssertionsChain<T> NotEqual<TOther>(TOther expected)
        where TOther : struct, INumberBase<TOther>
    {
        T expectedAsT;
        try
        {
            expectedAsT = T.CreateChecked(expected);
        }
        catch (OverflowException)
        {
            // If the expected value can't be represented in T, then the value can't equal it
            return new NumericAssertionsChain<T>(this);
        }

        Verify.That(!EqualityComparer<T>.Default.Equals(Value, expectedAsT), $"Value should not equal {expected}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is zero.
    /// </summary>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    public NumericAssertionsChain<T> BeZero()
    {
        Verify.That(T.IsZero(Value), $"Value should be {T.Zero} but was {Value}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is not zero.
    /// </summary>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    public NumericAssertionsChain<T> NotBeZero()
    {
        Verify.That(!T.IsZero(Value), $"Value should not be {T.Zero}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is negative.
    /// </summary>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    public NumericAssertionsChain<T> BeNegative()
    {
        Verify.That(T.IsNegative(Value), $"Value should be negative but was {Value}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is not negative.
    /// </summary>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    public NumericAssertionsChain<T> NotBeNegative()
    {
        Verify.That(!T.IsNegative(Value), $"Value should not be negative but was {Value}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is positive.
    /// </summary>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    public NumericAssertionsChain<T> BePositive()
    {
        Verify.That(T.IsPositive(Value), $"Value should be positive but was {Value}.");

        return new NumericAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the numeric value is not positive.
    /// </summary>
    /// <returns>A <see cref="NumericAssertionsChain{T}" /> for chaining further assertions.</returns>
    public NumericAssertionsChain<T> NotBePositive()
    {
        Verify.That(!T.IsPositive(Value), $"Value should not be positive but was {Value}.");

        return new NumericAssertionsChain<T>(this);
    }
}
