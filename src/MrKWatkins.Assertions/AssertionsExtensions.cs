namespace MrKWatkins.Assertions;

public static class AssertionsExtensions
{
    public static AssertionsChain<T> BeNull<T>(this Assertions<T> assertions)
    {
        if (!ReferenceEquals(assertions.Value, null))
        {
            throw new AssertionException("Value should be null.");
        }

        return new AssertionsChain<T>(assertions);
    }

    public static AssertionsChain<T> NotBeNull<T>(this Assertions<T> assertions)
    {
        if (ReferenceEquals(assertions.Value, null))
        {
            throw new AssertionException("Value should not be null.");
        }

        return new AssertionsChain<T>(assertions);
    }
}