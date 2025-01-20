namespace MrKWatkins.Assertions;

public readonly struct ActionAssertionsChain<TException>
    where TException : Exception
{
    internal ActionAssertionsChain(TException exception)
    {
        Exception = exception;
    }

    public TException Exception { get; }

    public TException That => Exception;
}