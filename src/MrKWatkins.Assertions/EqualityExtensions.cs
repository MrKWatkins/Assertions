namespace MrKWatkins.Assertions;

[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public static class EqualityExtensions
{
    public static ObjectAssertionsChain<T> Equal<T>(this ObjectAssertions<T> assertions, T? expected)
        where T : notnull
    {
        if (assertions.Value is null)
        {
            Verify.That(expected is null, "Value should equal {0} but was null.", expected);
        }
        else
        {
            Verify.That(assertions.Value.Equals(expected), "Value should equal {0} but was {1}.", expected, assertions.Value);
        }

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotEqual<T>(this ObjectAssertions<T> assertions, T? expected)
        where T : notnull
    {
        if (assertions.Value is null)
        {
            Verify.That(expected is not null, "Value should not equal null.");
        }
        else
        {
            Verify.That(!assertions.Value.Equals(expected), "Value should not equal {0}.", expected);
        }

        return new ObjectAssertionsChain<T>(assertions);
    }
}