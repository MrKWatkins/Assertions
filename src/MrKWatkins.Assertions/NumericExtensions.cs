using System.Numerics;

namespace MrKWatkins.Assertions;

public static class NumericExtensions
{
    public static ObjectAssertionsChain<T> BeZero<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsZero(assertions.Value), $"Value should be {T.Zero} but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBeZero<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsZero(assertions.Value), $"Value should not be {T.Zero}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> BeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsNegative(assertions.Value), $"Value should be negative but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBeNegative<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsNegative(assertions.Value), $"Value should not be negative but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> BePositive<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(T.IsPositive(assertions.Value), $"Value should be positive but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }

    public static ObjectAssertionsChain<T> NotBePositive<T>(this ObjectAssertions<T> assertions)
        where T : INumberBase<T>
    {
        Verify.That(!T.IsPositive(assertions.Value), $"Value should not be positive but was {assertions.Value}.");

        return new ObjectAssertionsChain<T>(assertions);
    }
}