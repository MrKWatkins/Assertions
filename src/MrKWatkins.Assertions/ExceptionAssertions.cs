namespace MrKWatkins.Assertions;

public sealed class ExceptionAssertions<T> : ObjectAssertions<T>
    where T : Exception
{
    internal ExceptionAssertions(T? value)
        : base(value)
    {
    }

    public ExceptionAssertionsChain<T> HaveMessage(string expected)
    {
        NotBeNull();
        Verify.That(Value.Message == expected, $"Value should have Message {expected} but was {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    public ExceptionAssertionsChain<T> NotHaveMessage(string expected)
    {
        NotBeNull();
        Verify.That(Value.Message != expected, $"Value should not have Message {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    public ExceptionAssertionsChain<T> HaveMessageStartingWith(string expected)
    {
        NotBeNull();
        Verify.That(Value.Message.StartsWith(expected, StringComparison.InvariantCulture), $"Value should have Message starting with {expected} but was {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    public ExceptionAssertionsChain<T> NotHaveMessageStartingWith(string expected)
    {
        NotBeNull();
        Verify.That(!Value.Message.StartsWith(expected, StringComparison.InvariantCulture), $"Value should not have Message starting with {expected} but was {Value.Message}.");

        return new ExceptionAssertionsChain<T>(this);
    }

    public InnerExceptionAssertionsChain<TException> HaveInnerException<TException>()
        where TException : Exception
    {
        NotBeNull();
        Verify.That(Value.InnerException is not null, "Value should have an InnerException but was null.");
        Verify.That(Value.InnerException is TException, $"Value should have an InnerException of type {typeof(TException)} but was of type {Value.InnerException!.GetType()}.");

        return new InnerExceptionAssertionsChain<TException>((TException)Value.InnerException!);
    }

    public InnerExceptionAssertionsChain<TException> HaveInnerException<TException>(TException expected)
        where TException : Exception
    {
        NotBeNull();
        Verify.That(ReferenceEquals(Value.InnerException, expected), $"Value should have InnerException {expected} but was {Value.InnerException}.");

        return new InnerExceptionAssertionsChain<TException>((TException)Value.InnerException!);
    }

    public ExceptionAssertionsChain<T> NotHaveInnerException()
    {
        NotBeNull();
        Verify.That(Value.InnerException is null, $"Value should not have an InnerException but has {Value.InnerException}.");

        return new ExceptionAssertionsChain<T>(this);
    }
}