using System.Numerics;
using MrKWatkins.Assertions.Assertions;

namespace MrKWatkins.Assertions;

public static class NumericAssertionsExtensions
{
    public static ObjectAssertionsChain<T> BeZero<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsZero(assertions.Value), "Value should be {0} but was {1}.", T.Zero, assertions.Value);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBeZero<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsZero(assertions.Value), "Value should not be {0}.", T.Zero);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> BeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsNegative(assertions.Value), "Value should be negative but was {0}.", assertions.Value);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsNegative(assertions.Value), "Value should not be negative but was {0}.", assertions.Value);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> BePositive<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsPositive(assertions.Value), "Value should be positive but was {0}.", assertions.Value);

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBePositive<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsPositive(assertions.Value), "Value should not be positive but was {0}.", assertions.Value);

        return new ObjectAssertionsChain<T>(assertions);
    }
}