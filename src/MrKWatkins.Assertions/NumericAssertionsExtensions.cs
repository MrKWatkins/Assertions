using System.Numerics;
using MrKWatkins.Assertions.Assertions;

namespace MrKWatkins.Assertions;

public static class NumericAssertionsExtensions
{
    public static ObjectAssertionsChain<T> BeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsNegative(assertions.Value), "Value should be negative.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsNegative(assertions.Value), "Value should not be negative.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> BePositive<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsPositive(assertions.Value), "Value should be positive.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBePositive<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsPositive(assertions.Value), "Value should not be positive.");

        return new ObjectAssertionsChain<T>(assertions);
    }
}