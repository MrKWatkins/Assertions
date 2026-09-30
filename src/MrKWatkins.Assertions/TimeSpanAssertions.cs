namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for <see cref="TimeSpan" /> values.
/// </summary>
/// <param name="value">The value to assert on.</param>
public sealed class TimeSpanAssertions(TimeSpan value) : ObjectAssertions<TimeSpan>(value)
{
    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is <see cref="TimeSpan.Zero" />.
    /// </summary>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeZero()
    {
        Verify.That(Value == TimeSpan.Zero, $"Value should be zero but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is not <see cref="TimeSpan.Zero" />.
    /// </summary>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain NotBeZero()
    {
        Verify.That(Value != TimeSpan.Zero, "Value should not be zero.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is negative.
    /// </summary>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeNegative()
    {
        Verify.That(Value < TimeSpan.Zero, $"Value should be negative but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is not negative.
    /// </summary>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain NotBeNegative()
    {
        Verify.That(Value >= TimeSpan.Zero, $"Value should not be negative but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is positive.
    /// </summary>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BePositive()
    {
        Verify.That(Value > TimeSpan.Zero, $"Value should be positive but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is not positive.
    /// </summary>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain NotBePositive()
    {
        Verify.That(Value <= TimeSpan.Zero, $"Value should not be positive but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is less than the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="TimeSpan" /> should be less than.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeLessThan(TimeSpan expected)
    {
        Verify.That(Value < expected, $"Value should be less than {expected} but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is less than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="TimeSpan" /> should be less than or equal to.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeLessThanOrEqualTo(TimeSpan expected)
    {
        Verify.That(Value <= expected, $"Value should be less than or equal to {expected} but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is greater than the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="TimeSpan" /> should be greater than.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeGreaterThan(TimeSpan expected)
    {
        Verify.That(Value > expected, $"Value should be greater than {expected} but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is greater than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="TimeSpan" /> should be greater than or equal to.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeGreaterThanOrEqualTo(TimeSpan expected)
    {
        Verify.That(Value >= expected, $"Value should be greater than or equal to {expected} but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is between the specified minimum and maximum values, inclusive.
    /// </summary>
    /// <param name="minimum">The minimum allowed value.</param>
    /// <param name="maximum">The maximum allowed value.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeInRange(TimeSpan minimum, TimeSpan maximum)
    {
        Verify.That(minimum <= Value && Value <= maximum, $"Value should be in the range {minimum} to {maximum} but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is approximately equal to the expected value within the specified precision.
    /// </summary>
    /// <param name="expected">The expected value.</param>
    /// <param name="precision">The maximum allowed difference between the value and the expected value.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain BeApproximately(TimeSpan expected, TimeSpan precision)
    {
        Verify.That(IsApproximately(expected, precision), $"Value should be approximately {expected} (±{precision}) but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the <see cref="TimeSpan" /> value is not approximately equal to the specified value within the specified precision.
    /// </summary>
    /// <param name="expected">The value that is not expected.</param>
    /// <param name="precision">The maximum difference between the value and <paramref name="expected" /> that is considered approximately equal.</param>
    /// <returns>A <see cref="TimeSpanAssertionsChain" /> for chaining further assertions.</returns>
    public TimeSpanAssertionsChain NotBeApproximately(TimeSpan expected, TimeSpan precision)
    {
        Verify.That(!IsApproximately(expected, precision), $"Value should not be approximately {expected} (±{precision}) but was {Value}.");

        return new TimeSpanAssertionsChain(this);
    }

    // Use Int128 for the difference to avoid overflow with extreme values such as TimeSpan.MinValue and TimeSpan.MaxValue.
    [Pure]
    private bool IsApproximately(TimeSpan expected, TimeSpan precision) => Int128.Abs((Int128)Value.Ticks - expected.Ticks) <= precision.Ticks;
}