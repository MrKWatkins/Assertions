namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for exception values.
/// </summary>
/// <typeparam name="T">The type of the exception being asserted on.</typeparam>
/// <param name="value">The exception to assert on.</param>
public sealed class ExceptionAssertions<T>(T? value) : ObjectAssertions<T>(value)
    where T : Exception
{
    /// <summary>
    /// Asserts that the exception has the specified message.
    /// </summary>
    /// <param name="expected">The expected message.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.InvariantCulture" />.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ExceptionAssertionsChain<T> HaveMessage(string expected, StringComparison comparison = StringComparison.InvariantCulture)
    {
        NotBeNull();
        Verify.That(string.Equals(Value.Message, expected, comparison), $"Value should have Message {expected}{FormatComparison(comparison):L} but was {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the exception does not have the specified message.
    /// </summary>
    /// <param name="expected">The message that is not expected.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.InvariantCulture" />.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ExceptionAssertionsChain<T> NotHaveMessage(string expected, StringComparison comparison = StringComparison.InvariantCulture)
    {
        NotBeNull();
        Verify.That(!string.Equals(Value.Message, expected, comparison), $"Value should not have Message {Value.Message}{FormatComparison(comparison):L}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the exception message starts with the specified string.
    /// </summary>
    /// <param name="expected">The expected message prefix.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.InvariantCulture" />.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ExceptionAssertionsChain<T> HaveMessageStartingWith(string expected, StringComparison comparison = StringComparison.InvariantCulture)
    {
        NotBeNull();
        Verify.That(Value.Message.StartsWith(expected, comparison), $"Value should have Message starting with {expected}{FormatComparison(comparison):L} but was {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the exception message does not start with the specified string.
    /// </summary>
    /// <param name="expected">The message prefix that is not expected.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.InvariantCulture" />.</param>
    /// <returns>An <see cref="ExceptionAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ExceptionAssertionsChain<T> NotHaveMessageStartingWith(string expected, StringComparison comparison = StringComparison.InvariantCulture)
    {
        NotBeNull();
        Verify.That(!Value.Message.StartsWith(expected, comparison), $"Value should not have Message starting with {expected}{FormatComparison(comparison):L} but was {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    /// <summary>
    /// Asserts that the exception has an inner exception of the specified type.
    /// </summary>
    /// <typeparam name="TException">The expected inner exception type.</typeparam>
    /// <returns>An <see cref="InnerExceptionAssertionsChain{TException}" /> for asserting on the inner exception.</returns>
    public InnerExceptionAssertionsChain<TException> HaveInnerException<TException>()
        where TException : Exception
    {
        NotBeNull();
        Verify.That(Value.InnerException is not null, "Value should have an InnerException but was null.");
        Verify.That(Value.InnerException is TException, $"Value should have an InnerException of type {typeof(TException)} but was of type {Value.InnerException!.GetType()}.");

        return new InnerExceptionAssertionsChain<TException>((TException)Value.InnerException!);
    }

    /// <summary>
    /// Asserts that the exception has the exact specified inner exception instance.
    /// </summary>
    /// <typeparam name="TException">The expected inner exception type.</typeparam>
    /// <param name="expected">The expected inner exception instance.</param>
    /// <returns>An <see cref="InnerExceptionAssertionsChain{TException}" /> for asserting on the inner exception.</returns>
    public InnerExceptionAssertionsChain<TException> HaveInnerException<TException>(TException expected)
        where TException : Exception
    {
        NotBeNull();
        Verify.That(ReferenceEquals(Value.InnerException, expected), $"Value should have InnerException {expected} but was {Value.InnerException}.");

        return new InnerExceptionAssertionsChain<TException>((TException)Value.InnerException!);
    }

    /// <summary>
    /// Asserts that the exception does not have an inner exception.
    /// </summary>
    /// <returns>An <see cref="ExceptionAssertionsChain{T}" /> for chaining further assertions.</returns>
    public ExceptionAssertionsChain<T> NotHaveInnerException()
    {
        NotBeNull();
        Verify.That(Value.InnerException is null, $"Value should not have an InnerException but has {Value.InnerException}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    [Pure]
    private static string FormatComparison(StringComparison comparison) =>
        comparison == StringComparison.InvariantCulture ? "" : $" (using {comparison})";
}