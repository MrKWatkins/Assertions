namespace MrKWatkins.Assertions;

public static class ExceptionExtensions
{
    public static ObjectAssertionsChain<TException> HaveMessage<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.Message == expected, "Value should have message {0} but was {1}.", assertions.Value.Message, expected);

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveMessage<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.Message != expected, "Value should not have message {0}.", assertions.Value.Message);

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> HaveParamName<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : ArgumentException
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.ParamName == expected, "Value should have param name {0} but was {1}.", assertions.Value.ParamName, expected);

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveParamName<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : ArgumentException
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.ParamName != expected, "Value should not have param name {0}.", assertions.Value.ParamName);

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> HaveInnerException<TException>(this ObjectAssertions<TException> assertions, Exception expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(ReferenceEquals(assertions.Value.InnerException, expected), "Value should have inner exception {0} but was {1}.", expected, assertions.Value.InnerException);

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveInnerException<TException>(this ObjectAssertions<TException> assertions, Exception expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(!ReferenceEquals(assertions.Value.InnerException, expected), "Value should not have inner exception {0}.", assertions.Value.InnerException);

        return new ObjectAssertionsChain<TException>(assertions);
    }
}