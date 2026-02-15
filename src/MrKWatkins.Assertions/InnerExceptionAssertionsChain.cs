namespace MrKWatkins.Assertions;

/// <summary>
/// Enables further assertions on an inner exception after a successful inner exception assertion.
/// </summary>
/// <typeparam name="TException">The type of the inner exception.</typeparam>
/// <param name="exception">The inner exception.</param>
public readonly struct InnerExceptionAssertionsChain<TException>(TException exception)
    where TException : Exception
{
    /// <summary>
    /// Gets the inner exception, for use in further assertions via <c>.Should()</c>.
    /// </summary>
    public TException That => exception;
}