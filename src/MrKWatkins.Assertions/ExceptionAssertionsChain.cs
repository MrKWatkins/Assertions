namespace MrKWatkins.Assertions;

public readonly struct ExceptionAssertionsChain<T>(ExceptionAssertions<T> exceptionAssertions)
    where T : Exception
{
    public ExceptionAssertions<T> And { get; } = exceptionAssertions;

    public T Value => And.Value;
}