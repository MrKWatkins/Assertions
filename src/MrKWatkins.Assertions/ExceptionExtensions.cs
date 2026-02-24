namespace MrKWatkins.Assertions;

/// <summary>
/// Extension methods that provide exception-specific assertions.
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    /// Asserts that the <see cref="ArgumentException" /> has the specified parameter name.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The expected parameter name.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{TException}" /> for chaining further assertions.</returns>
    public static ExceptionAssertionsChain<TException> HaveParamName<TException>(this ExceptionAssertions<TException> assertions, string expected)
        where TException : ArgumentException
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.ParamName == expected, $"Value should have ParamName {expected} but was {assertions.Value.ParamName}.");

        return new ExceptionAssertionsChain<TException>(assertions);
    }

    /// <summary>
    /// Asserts that the <see cref="ArgumentException" /> does not have the specified parameter name.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The parameter name that is not expected.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{TException}" /> for chaining further assertions.</returns>
    public static ExceptionAssertionsChain<TException> NotHaveParamName<TException>(this ExceptionAssertions<TException> assertions, string expected)
        where TException : ArgumentException
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.ParamName != expected, $"Value should not have ParamName {assertions.Value.ParamName}.");

        return new ExceptionAssertionsChain<TException>(assertions);
    }

    /// <summary>
    /// Asserts that the <see cref="ArgumentOutOfRangeException" /> has the specified actual value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The expected actual value.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{TException}" /> for chaining further assertions.</returns>
    public static ExceptionAssertionsChain<TException> HaveActualValue<TException>(this ExceptionAssertions<TException> assertions, object expected)
        where TException : ArgumentOutOfRangeException
    {
        assertions.NotBeNull();
        Verify.That(Equals(assertions.Value.ActualValue, expected), $"Value should have ActualValue {expected} but was {assertions.Value.ActualValue}.");

        return new ExceptionAssertionsChain<TException>(assertions);
    }

    /// <summary>
    /// Asserts that the <see cref="ArgumentOutOfRangeException" /> does not have the specified actual value.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    /// <param name="assertions">The assertions object.</param>
    /// <param name="expected">The actual value that is not expected.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{TException}" /> for chaining further assertions.</returns>
    public static ExceptionAssertionsChain<TException> NotHaveActualValue<TException>(this ExceptionAssertions<TException> assertions, object expected)
        where TException : ArgumentOutOfRangeException
    {
        assertions.NotBeNull();
        Verify.That(!Equals(assertions.Value.ActualValue, expected), $"Value should not have ActualValue {assertions.Value.ActualValue}.");

        return new ExceptionAssertionsChain<TException>(assertions);
    }
}