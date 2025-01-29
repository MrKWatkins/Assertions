namespace MrKWatkins.Assertions;

public static class ExceptionExtensions
{

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
}