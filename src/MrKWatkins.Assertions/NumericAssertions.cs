namespace MrKWatkins.Assertions;

/// <summary>
/// Base class for assertions on numeric values, and other values that have a zero and a sign such as <see cref="TimeSpan" />.
/// </summary>
/// <typeparam name="TSelf">The type of the derived assertions class, returned from <see cref="AssertionsChain{TAssertions, T}.And" /> to allow chaining.</typeparam>
/// <typeparam name="T">The type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
/// <param name="zero">The zero value for <typeparamref name="T" />.</param>
/// <remarks>
/// Zero is neither positive nor negative. Values that are not ordered, such as <see cref="double.NaN" />, are not zero, positive or negative.
/// </remarks>
public abstract class NumericAssertions<TSelf, T>(T value, T zero) : ComparableAssertions<TSelf, T>(value)
    where TSelf : NumericAssertions<TSelf, T>
    where T : IComparable<T>
{
    /// <summary>
    /// Asserts that the value is zero.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeZero()
    {
        Verify.That(Compare(zero) == 0, $"Value should be zero but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is not zero.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> NotBeZero()
    {
        Verify.That(Compare(zero) != 0, "Value should not be zero.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is negative, i.e. less than zero.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeNegative()
    {
        Verify.That(Compare(zero) < 0, $"Value should be negative but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is not negative, i.e. not less than zero.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> NotBeNegative()
    {
        Verify.That(!(Compare(zero) < 0), $"Value should not be negative but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is positive, i.e. greater than zero.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BePositive()
    {
        Verify.That(Compare(zero) > 0, $"Value should be positive but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is not positive, i.e. not greater than zero.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> NotBePositive()
    {
        Verify.That(!(Compare(zero) > 0), $"Value should not be positive but was {Value}.");

        return Chain();
    }
}