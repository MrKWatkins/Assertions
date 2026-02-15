namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide boolean-specific assertions.
/// </summary>
public static class BooleanExtensions
{
    /// <summary>
    /// Asserts that the boolean value is <see langword="true" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool> BeTrue(this ObjectAssertions<bool> assertions)
    {
        Verify.That(assertions.Value, "Value should be true but was false.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    /// <summary>
    /// Asserts that the nullable boolean value is <see langword="true" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool?> BeTrue(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(assertions.Value.HasValue && assertions.Value.Value, $"Value should be true but was {assertions.Value}.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }

    /// <summary>
    /// Asserts that the boolean value is not <see langword="true" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool> NotBeTrue(this ObjectAssertions<bool> assertions)
    {
        Verify.That(!assertions.Value, "Value should not be true but was false.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    /// <summary>
    /// Asserts that the nullable boolean value is not <see langword="true" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool?> NotBeTrue(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(!assertions.Value.HasValue || !assertions.Value.Value, "Value should not be true.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }

    /// <summary>
    /// Asserts that the boolean value is <see langword="false" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool> BeFalse(this ObjectAssertions<bool> assertions)
    {
        Verify.That(!assertions.Value, "Value should be false but was true.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    /// <summary>
    /// Asserts that the nullable boolean value is <see langword="false" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool?> BeFalse(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(assertions.Value.HasValue && !assertions.Value.Value, $"Value should be false but was {assertions.Value}.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }

    /// <summary>
    /// Asserts that the boolean value is not <see langword="false" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool> NotBeFalse(this ObjectAssertions<bool> assertions)
    {
        Verify.That(assertions.Value, "Value should not be false.");

        return new ObjectAssertionsChain<bool>(assertions);
    }

    /// <summary>
    /// Asserts that the nullable boolean value is not <see langword="false" />.
    /// </summary>
    /// <param name="assertions">The assertions object.</param>
    /// <returns>An <see cref="ObjectAssertionsChain{T}" /> for chaining further assertions.</returns>
    public static ObjectAssertionsChain<bool?> NotBeFalse(this ObjectAssertions<bool?> assertions)
    {
        Verify.That(!assertions.Value.HasValue || assertions.Value.Value, "Value should not be false.");

        return new ObjectAssertionsChain<bool?>(assertions);
    }
}