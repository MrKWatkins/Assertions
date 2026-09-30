namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for boolean values.
/// </summary>
/// <param name="value">The boolean value to assert on.</param>
public sealed class BooleanAssertions(bool value) : ObjectAssertions<BooleanAssertions, bool>(value)
{
    /// <summary>
    /// Asserts that the boolean value is <see langword="true" />.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<BooleanAssertions, bool> BeTrue()
    {
        Verify.That(Value, "Value should be true but was false.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the boolean value is not <see langword="true" />.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<BooleanAssertions, bool> NotBeTrue()
    {
        Verify.That(!Value, "Value should not be true.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the boolean value is <see langword="false" />.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<BooleanAssertions, bool> BeFalse()
    {
        Verify.That(!Value, "Value should be false but was true.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the boolean value is not <see langword="false" />.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<BooleanAssertions, bool> NotBeFalse()
    {
        Verify.That(Value, "Value should not be false.");

        return Chain();
    }
}