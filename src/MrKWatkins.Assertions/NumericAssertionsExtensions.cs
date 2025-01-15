using System.Numerics;

namespace MrKWatkins.Assertions;

public static class NumericAssertionsExtensions
{
    public static AssertionsChain<T> BeNegative<T>(this Assertions<T> assertions)
        where T : INumberBase<T>
    {
        if (!T.IsNegative(assertions.Value))
        {
            throw new AssertionException("Value should be negative.");
        }

        return new AssertionsChain<T>(assertions);
    }

    public static AssertionsChain<T> NotBeNegative<T>(this Assertions<T> assertions)
        where T : INumberBase<T>
    {
        if (T.IsNegative(assertions.Value))
        {
            throw new AssertionException("Value should not be negative.");
        }

        return new AssertionsChain<T>(assertions);
    }
}