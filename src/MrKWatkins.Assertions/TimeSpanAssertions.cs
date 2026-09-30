namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for <see cref="TimeSpan" /> values.
/// </summary>
/// <param name="value">The value to assert on.</param>
public sealed class TimeSpanAssertions(TimeSpan value) : NumericAssertions<TimeSpanAssertions, TimeSpan>(value, TimeSpan.Zero)
{
    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is approximately equal to the expected value within the specified precision.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="precision">The maximum allowed difference between the value and the expected value.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TimeSpanAssertions, TimeSpan> BeApproximately(TimeSpan expected, TimeSpan precision)
    {
        Verify.That(IsApproximately(expected, precision), $"Value should be approximately {expected} (±{precision}) but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is not approximately equal to the specified value within the specified precision.
    /// </summary>
    /// <param name="expected">The value that is not expected.</param>
    /// <param name="precision">The maximum difference between the value and <paramref name="expected" /> that is considered approximately equal.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<TimeSpanAssertions, TimeSpan> NotBeApproximately(TimeSpan expected, TimeSpan precision)
    {
        Verify.That(!IsApproximately(expected, precision), $"Value should not be approximately {expected} (±{precision}) but was {Value}.");

        return Chain();
    }

    // Use Int128 for the difference to avoid overflow with extreme values such as TimeSpan.MinValue and TimeSpan.MaxValue.
    [Pure]
    private bool IsApproximately(TimeSpan expected, TimeSpan precision) => Int128.Abs((Int128)Value.Ticks - expected.Ticks) <= precision.Ticks;
}