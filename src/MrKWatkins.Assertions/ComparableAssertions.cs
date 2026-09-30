namespace MrKWatkins.Assertions;

/// <summary>
/// Base class for assertions on values that can be ordered using <see cref="IComparable{T}" />.
/// </summary>
/// <typeparam name="TSelf">The type of the derived assertions class, returned from <see cref="AssertionsChain{TAssertions, T}.And" /> to allow chaining.</typeparam>
/// <typeparam name="T">The type of the value being asserted on.</typeparam>
/// <param name="value">The value to assert on.</param>
/// <remarks>
/// Values that are not ordered, such as <see cref="double.NaN" />, are not less than, greater than or equal to anything, matching the behaviour of the comparison operators.
/// </remarks>
public abstract class ComparableAssertions<TSelf, T>(T value) : ObjectAssertions<TSelf, T>(value)
    where TSelf : ComparableAssertions<TSelf, T>
    where T : IComparable<T>
{
    /// <summary>
    /// Asserts that the value is less than the expected value.
    /// </summary>
    /// <param name="expected">The value the value should be less than.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeLessThan(T expected)
    {
        Verify.That(Compare(expected) < 0, $"Value should be less than {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is less than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the value should be less than or equal to.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeLessThanOrEqualTo(T expected)
    {
        Verify.That(Compare(expected) <= 0, $"Value should be less than or equal to {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is greater than the expected value.
    /// </summary>
    /// <param name="expected">The value the value should be greater than.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeGreaterThan(T expected)
    {
        Verify.That(Compare(expected) > 0, $"Value should be greater than {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is greater than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the value should be greater than or equal to.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeGreaterThanOrEqualTo(T expected)
    {
        Verify.That(Compare(expected) >= 0, $"Value should be greater than or equal to {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the value is between the specified minimum and maximum values, inclusive.
    /// </summary>
    /// <param name="minimum">The minimum allowed value.</param>
    /// <param name="maximum">The maximum allowed value.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TSelf, T> BeInRange(T minimum, T maximum)
    {
        Verify.That(Compare(minimum) >= 0 && Compare(maximum) <= 0, $"Value should be in the range {minimum} to {maximum} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Compares the value to <paramref name="other" />.
    /// </summary>
    /// <returns>
    /// A negative number if the value is less than <paramref name="other" />, zero if they are equal, a positive number if the value is greater than
    /// <paramref name="other" />, or <see langword="null" /> if either is unordered.
    /// </returns>
    [Pure]
    private protected int? Compare(T other) => IsUnordered(Value) || IsUnordered(other) ? null : Comparer<T>.Default.Compare(Value, other);

    /// <summary>
    /// Returns whether the specified value is unordered, i.e. cannot be meaningfully compared to any other value, such as <see cref="double.NaN" />.
    /// </summary>
    [Pure]
    private protected virtual bool IsUnordered(T value) => false;
}