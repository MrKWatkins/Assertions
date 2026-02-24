namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for async actions (delegates returning <see cref="Task"/>), such as verifying that exceptions are thrown.
/// </summary>
/// <param name="action">The async action to assert on.</param>
public sealed class AsyncActionAssertions(Func<Task> action)
{
    /// <summary>
    /// Asserts that the async action throws an exception of the specified type.
    /// </summary>
    /// <typeparam name="TException">The expected exception type.</typeparam>
    /// <returns>A <see cref="Task{TResult}"/> that resolves to an <see cref="ActionAssertionsChain{TException}" /> containing the thrown exception.</returns>
    public async Task<ActionAssertionsChain<TException>> ThrowAsync<TException>()
        where TException : Exception
    {
        TException? thrown = null;
        try
        {
            await action().ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            if (exception is not TException typedException)
            {
                throw Verify.CreateException($"Function should throw {Format.PrefixWithAOrAn(typeof(TException).Name)} but threw {Format.PrefixWithAOrAn(exception.GetType().Name)} with message {Format.Value(exception.Message)}.", exception);
            }
            thrown = typedException;
        }

        if (thrown == null)
        {
            throw Verify.CreateException($"Function should throw {Format.PrefixWithAOrAn(typeof(TException).Name)}.");
        }

        return new ActionAssertionsChain<TException>(thrown);
    }

    /// <summary>
    /// Asserts that the async action throws an exception of the specified type with the specified message.
    /// </summary>
    /// <typeparam name="TException">The expected exception type.</typeparam>
    /// <param name="expectedMessage">The expected exception message.</param>
    /// <returns>A <see cref="Task{TResult}"/> that resolves to an <see cref="ActionAssertionsChain{TException}" /> containing the thrown exception.</returns>
    public async Task<ActionAssertionsChain<TException>> ThrowAsync<TException>(string expectedMessage)
        where TException : Exception
    {
        var chain = await ThrowAsync<TException>().ConfigureAwait(false);

        chain.That.Should().HaveMessage(expectedMessage);

        return chain;
    }

    /// <summary>
    /// Asserts that the async action throws an exception of the specified type with the specified message and inner exception.
    /// </summary>
    /// <typeparam name="TException">The expected exception type.</typeparam>
    /// <param name="expectedMessage">The expected exception message.</param>
    /// <param name="expectedInnerException">The expected inner exception, or <see langword="null" /> to assert no inner exception.</param>
    /// <returns>A <see cref="Task{TResult}"/> that resolves to an <see cref="ActionAssertionsChain{TException}" /> containing the thrown exception.</returns>
    public async Task<ActionAssertionsChain<TException>> ThrowAsync<TException>(string expectedMessage, Exception? expectedInnerException)
        where TException : Exception
    {
        var chain = await ThrowAsync<TException>().ConfigureAwait(false);

        chain.That.Should().HaveMessage(expectedMessage);
        if (expectedInnerException != null)
        {
            chain.That.Should().HaveInnerException(expectedInnerException);
        }
        else
        {
            chain.That.Should().NotHaveInnerException();
        }

        return chain;
    }

    /// <summary>
    /// Asserts that the async action throws the exact specified exception instance.
    /// </summary>
    /// <typeparam name="TException">The expected exception type.</typeparam>
    /// <param name="expected">The expected exception instance.</param>
    /// <returns>A <see cref="Task{TResult}"/> that resolves to an <see cref="ActionAssertionsChain{TException}" /> containing the thrown exception.</returns>
    public async Task<ActionAssertionsChain<TException>> ThrowAsync<TException>(TException expected)
        where TException : Exception
    {
        var chain = await ThrowAsync<TException>().ConfigureAwait(false);

        chain.Exception.Should().BeTheSameInstanceAs(expected);

        return chain;
    }

    /// <summary>
    /// Asserts that the async action throws an <see cref="ArgumentException" /> with the specified message and parameter name.
    /// </summary>
    /// <param name="expectedMessage">The expected exception message.</param>
    /// <param name="expectedParamName">The expected parameter name.</param>
    /// <returns>A <see cref="Task{TResult}"/> that resolves to an <see cref="ActionAssertionsChain{TException}" /> containing the thrown exception.</returns>
    public async Task<ActionAssertionsChain<ArgumentException>> ThrowArgumentExceptionAsync(string expectedMessage, string expectedParamName)
    {
        var chain = await ThrowAsync<ArgumentException>().ConfigureAwait(false);

        chain.Exception.Should().HaveMessageStartingWith(expectedMessage).And.HaveParamName(expectedParamName);

        return chain;
    }

    /// <summary>
    /// Asserts that the async action throws an <see cref="ArgumentOutOfRangeException" /> with the specified message, parameter name and actual value.
    /// </summary>
    /// <param name="expectedMessage">The expected exception message.</param>
    /// <param name="expectedParamName">The expected parameter name.</param>
    /// <param name="expectedActualValue">The expected actual value.</param>
    /// <returns>A <see cref="Task{TResult}"/> that resolves to an <see cref="ActionAssertionsChain{TException}" /> containing the thrown exception.</returns>
    public async Task<ActionAssertionsChain<ArgumentOutOfRangeException>> ThrowArgumentOutOfRangeExceptionAsync(string expectedMessage, string expectedParamName, object expectedActualValue)
    {
        var chain = await ThrowAsync<ArgumentOutOfRangeException>().ConfigureAwait(false);

        chain.Exception.Should().HaveMessageStartingWith(expectedMessage).And.HaveParamName(expectedParamName).And.HaveActualValue(expectedActualValue);

        return chain;
    }

    /// <summary>
    /// Asserts that the async action does not throw any exception.
    /// </summary>
    /// <returns>A <see cref="Task"/> that completes successfully if no exception is thrown.</returns>
    public async Task NotThrowAsync()
    {
        try
        {
            await action().ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            throw Verify.CreateException($"Function should not throw but threw {Format.PrefixWithAOrAn(exception.GetType().Name)} with message {Format.Value(exception.Message)}.", exception);
        }
    }
}