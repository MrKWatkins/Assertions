namespace MrKWatkins.Assertions;

public static class ObjectAssertionsExtensions
{
    public static ObjectAssertionsChain<T> BeNull<T>(this ObjectAssertions<T> assertions)
    {
        Verify.That(ReferenceEquals(assertions.Value, null), "Value should {0}be null.", assertions.IsNot);

        return new ObjectAssertionsChain<T>(assertions);
    }
}