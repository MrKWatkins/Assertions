namespace MrKWatkins.Assertions;

public static class ExceptionExtensions
{
    public static ObjectAssertionsChain<TException> HaveMessage<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.Message == expected, $"Value should have Message {expected} but was {assertions.Value.Message}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveMessage<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.Message != expected, $"Value should not have Message {assertions.Value.Message}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> HaveMessageStartingWith<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.Message.StartsWith(expected, StringComparison.InvariantCulture), $"Value should have Message starting with {expected} but was {assertions.Value.Message}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveMessageStartingWith<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(!assertions.Value.Message.StartsWith(expected, StringComparison.InvariantCulture), $"Value should not have Message starting with {expected} but was {assertions.Value.Message}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> HaveParamName<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : ArgumentException
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.ParamName == expected, $"Value should have ParamName {expected} but was {assertions.Value.ParamName}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveParamName<TException>(this ObjectAssertions<TException> assertions, string expected)
        where TException : ArgumentException
    {
        assertions.NotBeNull();
        Verify.That(assertions.Value.ParamName != expected, $"Value should not have ParamName {assertions.Value.ParamName}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> HaveActualValue<TException>(this ObjectAssertions<TException> assertions, object expected)
        where TException : ArgumentOutOfRangeException
    {
        assertions.NotBeNull();
        Verify.That(Equals(assertions.Value.ActualValue, expected), $"Value should have ActualValue {expected} but was {assertions.Value.ActualValue}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveActualValue<TException>(this ObjectAssertions<TException> assertions, object expected)
        where TException : ArgumentOutOfRangeException
    {
        assertions.NotBeNull();
        Verify.That(!Equals(assertions.Value.ActualValue, expected), $"Value should not have ActualValue {assertions.Value.ActualValue}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> HaveInnerException<TException>(this ObjectAssertions<TException> assertions, Exception expected)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(ReferenceEquals(assertions.Value.InnerException, expected), $"Value should have InnerException {expected} but was {assertions.Value.InnerException}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }

    public static ObjectAssertionsChain<TException> NotHaveInnerException<TException>(this ObjectAssertions<TException> assertions)
        where TException : Exception
    {
        assertions.NotBeNull();
        Verify.That(ReferenceEquals(assertions.Value.InnerException, null), $"Value should not have an InnerException but has {assertions.Value.InnerException}.");

        return new ObjectAssertionsChain<TException>(assertions);
    }
}