namespace MrKWatkins.Assertions;

public readonly struct InnerExceptionAssertionsChain<TException>(TException exception)
    where TException : Exception
{
    public TException That => exception;
}