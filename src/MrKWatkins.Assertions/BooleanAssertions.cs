namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for boolean values.
/// </summary>
/// <param name="value">The boolean value to assert on.</param>
public sealed class BooleanAssertions(bool value) : ObjectAssertions<bool>(value)
{
    /// <summary>
    /// Asserts that the boolean value is <see langword="true" />.
    /// </summary>
    /// <returns>A <see cref="BooleanAssertionsChain" /> for chaining further assertions.</returns>
    public BooleanAssertionsChain BeTrue()
    {
        Verify.That(Value, "Value should be true but was false.");

        return new BooleanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the boolean value is not <see langword="true" />.
    /// </summary>
    /// <returns>A <see cref="BooleanAssertionsChain" /> for chaining further assertions.</returns>
    public BooleanAssertionsChain NotBeTrue()
    {
        Verify.That(!Value, "Value should not be true.");

        return new BooleanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the boolean value is <see langword="false" />.
    /// </summary>
    /// <returns>A <see cref="BooleanAssertionsChain" /> for chaining further assertions.</returns>
    public BooleanAssertionsChain BeFalse()
    {
        Verify.That(!Value, "Value should be false but was true.");

        return new BooleanAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the boolean value is not <see langword="false" />.
    /// </summary>
    /// <returns>A <see cref="BooleanAssertionsChain" /> for chaining further assertions.</returns>
    public BooleanAssertionsChain NotBeFalse()
    {
        Verify.That(Value, "Value should not be false.");

        return new BooleanAssertionsChain(this);
    }
}