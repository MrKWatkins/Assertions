using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for integer values.
/// </summary>
/// <typeparam name="T">The integer type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
public sealed class IntegerAssertions<T>(T value) : ObjectAssertions<T>(value)
    where T : struct, IBinaryInteger<T>
{
    /// <summary>
    /// Asserts that the integer value is equal to the expected value. Supports comparing integer values of different types.
    /// </summary>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="expected">The expected value.</param>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// an <see cref="AssertionException"/> will be thrown with a descriptive message indicating the overflow.
    /// </remarks>
    public IntegerAssertionsChain<T> Equal<TOther>(TOther expected)
        where TOther : struct, IBinaryInteger<TOther>
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

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is not equal to the expected value. Supports comparing integer values of different types.
    /// </summary>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="expected">The value that is not expected.</param>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// the assertion succeeds because the value cannot equal something that cannot be represented in its type.
    /// </remarks>
    public IntegerAssertionsChain<T> NotEqual<TOther>(TOther expected)
        where TOther : struct, IBinaryInteger<TOther>
    {
        T expectedAsT;
        try
        {
            expectedAsT = T.CreateChecked(expected);
        }
        catch (OverflowException)
        {
            // If the expected value can't be represented in T, then the value can't equal it
            return new IntegerAssertionsChain<T>(this);
        }

        Verify.That(!EqualityComparer<T>.Default.Equals(Value, expectedAsT), $"Value should not equal {expected}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is zero.
    /// </summary>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BeZero()
    {
        Verify.That(T.IsZero(Value), $"Value should be {T.Zero} but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is not zero.
    /// </summary>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> NotBeZero()
    {
        Verify.That(!T.IsZero(Value), $"Value should not be {T.Zero}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is negative.
    /// </summary>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BeNegative()
    {
        Verify.That(T.IsNegative(Value), $"Value should be negative but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is not negative.
    /// </summary>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> NotBeNegative()
    {
        Verify.That(!T.IsNegative(Value), $"Value should not be negative but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is positive.
    /// </summary>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BePositive()
    {
        Verify.That(T.IsPositive(Value), $"Value should be positive but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is not positive.
    /// </summary>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> NotBePositive()
    {
        Verify.That(!T.IsPositive(Value), $"Value should not be positive but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is less than the expected value.
    /// </summary>
    /// <param name="expected">The value the integer should be less than.</param>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BeLessThan(T expected)
    {
        Verify.That(Value < expected, $"Value should be less than {expected} but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is less than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the integer should be less than or equal to.</param>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BeLessThanOrEqualTo(T expected)
    {
        Verify.That(Value <= expected, $"Value should be less than or equal to {expected} but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is greater than the expected value.
    /// </summary>
    /// <param name="expected">The value the integer should be greater than.</param>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BeGreaterThan(T expected)
    {
        Verify.That(Value > expected, $"Value should be greater than {expected} but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the integer value is greater than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the integer should be greater than or equal to.</param>
    /// <returns>An <see cref="IntegerAssertionsChain{T}" /> for chaining further assertions.</returns>
    public IntegerAssertionsChain<T> BeGreaterThanOrEqualTo(T expected)
    {
        Verify.That(Value >= expected, $"Value should be greater than or equal to {expected} but was {Value}.");

        return new IntegerAssertionsChain<T>(this);
    }
}