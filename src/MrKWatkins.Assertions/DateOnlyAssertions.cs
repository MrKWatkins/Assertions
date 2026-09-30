namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for <see cref="DateOnly" /> values.
/// </summary>
/// <param name="value">The value to assert on.</param>
public sealed class DateOnlyAssertions(DateOnly value) : ComparableAssertions<DateOnlyAssertions, DateOnly>(value)
{
    /// <summary>
    /// Asserts that the <see cref="DateOnly" /> value is before the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateOnly" /> should be before.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateOnlyAssertions, DateOnly> BeBefore(DateOnly expected)
    {
        Verify.That(Value < expected, $"Value should be before {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateOnly" /> value is on or before the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateOnly" /> should be on or before.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateOnlyAssertions, DateOnly> BeOnOrBefore(DateOnly expected)
    {
        Verify.That(Value <= expected, $"Value should be on or before {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateOnly" /> value is after the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateOnly" /> should be after.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateOnlyAssertions, DateOnly> BeAfter(DateOnly expected)
    {
        Verify.That(Value > expected, $"Value should be after {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateOnly" /> value is on or after the expected value.
    /// </summary>
    /// <param name="expected">The value the <see cref="DateOnly" /> should be on or after.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateOnlyAssertions, DateOnly> BeOnOrAfter(DateOnly expected)
    {
        Verify.That(Value >= expected, $"Value should be on or after {expected} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the <see cref="DateOnly" /> value falls on the expected day of the week.
    /// </summary>
    /// <param name="expected">The expected day of the week.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<DateOnlyAssertions, DateOnly> BeOnDayOfWeek(DayOfWeek expected)
    {
        Verify.That(Value.DayOfWeek == expected, $"Value should be on a {expected} but was {Value}, a {Value.DayOfWeek}.");

        return Chain();
    }
}