namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for <see cref="DateTimeOffset" /> values.
/// </summary>
/// <param name="value">The value to assert on.</param>
/// <remarks>
/// Like <see cref="DateTimeOffset.Equals(DateTimeOffset)" />, equality and comparisons are based on the point in time, ignoring the offset. For example
/// 12:00 +00:00 equals 13:00 +01:00. Use <see cref="BeExactly" /> to also compare the offset.
/// </remarks>
public sealed class DateTimeOffsetAssertions(DateTimeOffset value) : ComparableAssertions<DateTimeOffsetAssertions, DateTimeOffset>(value)
{
    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value is before the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateTimeOffset" /> should be before.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> BeBefore(DateTimeOffset expected)
    {
        Verify.That(Value < expected, $"Value should be before {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value is on or before the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateTimeOffset" /> should be on or before.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> BeOnOrBefore(DateTimeOffset expected)
    {
        Verify.That(Value <= expected, $"Value should be on or before {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value is after the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateTimeOffset" /> should be after.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> BeAfter(DateTimeOffset expected)
    {
        Verify.That(Value > expected, $"Value should be after {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value is on or after the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateTimeOffset" /> should be on or after.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> BeOnOrAfter(DateTimeOffset expected)
    {
        Verify.That(Value >= expected, $"Value should be on or after {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value is within the specified precision of the expected value.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="precision">The maximum allowed difference between the value and the expected value.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> BeApproximately(DateTimeOffset expected, TimeSpan precision)
    {
        Verify.That(IsApproximately(expected, precision), $"Value should be approximately {expected} (±{precision}) but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value is not within the specified precision of the specified value.
    /// </summary>
    /// <param name="expected">The value that is not expected.</param>
    /// <param name="precision">The maximum difference between the value and <paramref name="expected" /> that is considered approximately equal.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> NotBeApproximately(DateTimeOffset expected, TimeSpan precision)
    {
        Verify.That(!IsApproximately(expected, precision), $"Value should not be approximately {expected} (±{precision}) but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value represents the same point in time and has the same offset as the expected value.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> BeExactly(DateTimeOffset expected)
    {
        Verify.That(Value.EqualsExact(expected), $"Value should be exactly {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value does not represent the same point in time with the same offset as the specified value.
    /// </summary>
    /// <param name="expected">The value that is not expected.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> NotBeExactly(DateTimeOffset expected)
    {
        Verify.That(!Value.EqualsExact(expected), $"Value should not be exactly {expected}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateTimeOffset" /> value has the expected offset from UTC.
    /// </summary>
    /// <param name="expected">The expected offset.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateTimeOffsetAssertions, DateTimeOffset> HaveOffset(TimeSpan expected)
    {
        Verify.That(Value.Offset == expected, $"Value should have offset {expected} but had offset {Value.Offset}.");

        return Chain();
    }

    [Pure]
    private bool IsApproximately(DateTimeOffset expected, TimeSpan precision) => (Value - expected).Duration() <= precision;
}