using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide numeric-specific assertions.
/// </summary>
public static class NumericExtensions
{
    /// <summary>
    /// Asserts that the numeric value is equal to the expected value. Supports comparing numeric values of different types.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The expected value.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// an <see cref="AssertionException"/> will be thrown with a descriptive message indicating the overflow.
    /// </remarks>
    public static ObjectAssertionsChain<T> Equal<T, TOther>(this ObjectAssertions<T> assertions, TOther expected)
        where T : struct, INumberBase<T>
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

        Verify.That(EqualityComparer<T>.Default.Equals(assertions.Value, expectedAsT), $"Value should equal {expected} but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is not equal to the expected value. Supports comparing numeric values of different types.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The value that is not expected.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// the assertion succeeds because the value cannot equal something that cannot be represented in its type.
    /// </remarks>
    public static ObjectAssertionsChain<T> NotEqual<T, TOther>(this ObjectAssertions<T> assertions, TOther expected)
        where T : struct, INumberBase<T>
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
            return new ObjectAssertionsChain<T>(assertions);
        }

        Verify.That(!EqualityComparer<T>.Default.Equals(assertions.Value, expectedAsT), $"Value should not equal {expected}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is zero.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> BeZero<T>(this ObjectAssertions<T> assertions)
        where T : struct, INumberBase<T>
    {
        Verify.That(T.IsZero(assertions.Value), $"Value should be {T.Zero} but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is not zero.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> NotBeZero<T>(this ObjectAssertions<T> assertions)
        where T : struct, INumberBase<T>
    {
        Verify.That(!T.IsZero(assertions.Value), $"Value should not be {T.Zero}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is negative.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> BeNegative<T>(this ObjectAssertions<T> assertions)
        where T : struct, INumberBase<T>
    {
        Verify.That(T.IsNegative(assertions.Value), $"Value should be negative but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is not negative.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> NotBeNegative<T>(this ObjectAssertions<T> assertions)
        where T : struct, INumberBase<T>
    {
        Verify.That(!T.IsNegative(assertions.Value), $"Value should not be negative but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is positive.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> BePositive<T>(this ObjectAssertions<T> assertions)
        where T : struct, INumberBase<T>
    {
        Verify.That(T.IsPositive(assertions.Value), $"Value should be positive but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    /// <summary>
    /// Asserts that the numeric value is not positive.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<T> NotBePositive<T>(this ObjectAssertions<T> assertions)
        where T : struct, INumberBase<T>
    {
        Verify.That(!T.IsPositive(assertions.Value), $"Value should not be positive but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }
}
