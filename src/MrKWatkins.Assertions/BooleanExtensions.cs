namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide boolean-specific assertions for nullable boolean values.
/// </summary>
public static class BooleanExtensions
{
    /// <summary>
    /// Asserts that the nullable boolean value is <see langword="true" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public static AssertionsChain<ObjectAssertions<bool?>, bool?> BeTrue(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(assertions.Value.HasValue && assertions.Value.Value, $"Value should be true but was {assertions.Value}.");

        return assertions.Chain();
    }

    /// <summary>
    /// Asserts that the nullable boolean value is not <see langword="true" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public static AssertionsChain<ObjectAssertions<bool?>, bool?> NotBeTrue(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(!assertions.Value.HasValue || !assertions.Value.Value, "Value should not be true.");

        return assertions.Chain();
    }

    /// <summary>
    /// Asserts that the nullable boolean value is <see langword="false" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public static AssertionsChain<ObjectAssertions<bool?>, bool?> BeFalse(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(assertions.Value.HasValue && !assertions.Value.Value, $"Value should be false but was {assertions.Value}.");

        return assertions.Chain();
    }

    /// <summary>
    /// Asserts that the nullable boolean value is not <see langword="false" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public static AssertionsChain<ObjectAssertions<bool?>, bool?> NotBeFalse(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(!assertions.Value.HasValue || assertions.Value.Value, "Value should not be false.");

        return assertions.Chain();
    }
}