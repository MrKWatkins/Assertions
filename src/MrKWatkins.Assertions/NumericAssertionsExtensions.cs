using System.Numerics;

namespace MrKWatkins.Assertions;

public static class NumericAssertionsExtensions
{
    public static ObjectAssertionsChain<T> BeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsNegative(assertions.Value), "Value should {0}be negative.", assertions.IsNot);

        return new ObjectAssertionsChain<T>(assertions);
    }
}