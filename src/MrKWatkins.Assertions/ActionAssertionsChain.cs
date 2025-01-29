namespace MrKWatkins.Assertions;

public readonly struct ActionAssertionsChain<TException>(TException exception)
    where TException : Exception
{
    public TException Exception { get; } = exception;

    public TException That => Exception;
}