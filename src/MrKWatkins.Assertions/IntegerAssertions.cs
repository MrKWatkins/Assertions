using System.Numerics;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for integer values.
/// </summary>
/// <typeparam name="T">The integer type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
public sealed class IntegerAssertions<T>(T value) : NumericAssertions<IntegerAssertions<T>, T>(value, T.Zero)
    where T : struct, IBinaryInteger<T>
{
    /// <summary>
    /// Asserts that the integer value is equal to the expected value. Supports comparing integer values of different types.
    /// </summary>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="expected">The expected value.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// an <see cref="AssertionException"/> will be thrown with a descriptive message indicating the overflow.
    /// </remarks>
    public AssertionsChain<IntegerAssertions<T>, T> Equal<TOther>(TOther expected)
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

        return Chain();
    }

    /// <summary>
    /// Asserts that the integer value is not equal to the expected value. Supports comparing integer values of different types.
    /// </summary>
    /// <typeparam name="TOther">The type of the expected value.</typeparam>
    /// <param name="expected">The value that is not expected.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    /// <remarks>
    /// If the expected value cannot be represented in type <typeparamref name="T"/> (e.g., comparing a <c>byte</c> with <c>300</c>),
    /// the assertion succeeds because the value cannot equal something that cannot be represented in its type.
    /// </remarks>
    public AssertionsChain<IntegerAssertions<T>, T> NotEqual<TOther>(TOther expected)
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
            return Chain();
        }

        Verify.That(!EqualityComparer<T>.Default.Equals(Value, expectedAsT), $"Value should not equal {expected}.");

        return Chain();
    }
}