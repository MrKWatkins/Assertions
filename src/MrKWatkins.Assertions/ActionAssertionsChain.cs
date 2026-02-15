namespace MrKWatkins.Assertions;

/// <summary>
/// Enables access to an exception thrown by an action after a successful throw assertion.
/// </summary>
/// <typeparam name="TException">The type of the exception that was thrown.</typeparam>
/// <param name="exception">The exception that was thrown.</param>
public readonly struct ActionAssertionsChain<TException>(TException exception)
    where TException : Exception
{
    /// <summary>
    /// Gets the exception that was thrown.
    /// </summary>
    public TException Exception { get; } = exception;

    /// <summary>
    /// Gets the exception that was thrown, for use in further assertions via <c>.Should()</c>.
    /// </summary>
    public TException That => Exception;
}