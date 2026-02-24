namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for <see cref="decimal" /> values.
/// </summary>
/// <param name="value">The value to assert on.</param>
public sealed class DecimalAssertions(decimal value) : ObjectAssertions<decimal>(value)
{
    /// <summary>
    /// Asserts that the decimal value is zero.
    /// </summary>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BeZero()
    {
        Verify.That(Value == 0m, $"Value should be zero but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is not zero.
    /// </summary>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain NotBeZero()
    {
        Verify.That(Value != 0m, "Value should not be zero.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is negative.
    /// </summary>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BeNegative()
    {
        Verify.That(Value < 0m, $"Value should be negative but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is not negative.
    /// </summary>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain NotBeNegative()
    {
        Verify.That(Value >= 0m, $"Value should not be negative but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is positive.
    /// </summary>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BePositive()
    {
        Verify.That(Value > 0m, $"Value should be positive but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is not positive.
    /// </summary>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain NotBePositive()
    {
        Verify.That(Value <= 0m, $"Value should not be positive but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is less than the expected value.
    /// </summary>
    /// <param name="expected">The value the decimal should be less than.</param>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BeLessThan(decimal expected)
    {
        Verify.That(Value < expected, $"Value should be less than {expected} but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is less than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the decimal should be less than or equal to.</param>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BeLessThanOrEqualTo(decimal expected)
    {
        Verify.That(Value <= expected, $"Value should be less than or equal to {expected} but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is greater than the expected value.
    /// </summary>
    /// <param name="expected">The value the decimal should be greater than.</param>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BeGreaterThan(decimal expected)
    {
        Verify.That(Value > expected, $"Value should be greater than {expected} but was {Value}.");

        return new DecimalAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the decimal value is greater than or equal to the expected value.
    /// </summary>
    /// <param name="expected">The value the decimal should be greater than or equal to.</param>
    /// <returns>A <see cref="DecimalAssertionsChain" /> for chaining further assertions.</returns>
    public DecimalAssertionsChain BeGreaterThanOrEqualTo(decimal expected)
    {
        Verify.That(Value >= expected, $"Value should be greater than or equal to {expected} but was {Value}.");

        return new DecimalAssertionsChain(this);
    }
}