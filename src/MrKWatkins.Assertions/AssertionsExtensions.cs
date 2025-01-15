namespace MrKWatkins.Assertions;

public static class AssertionsExtensions
{
    public static AssertionsChain<T> NotBeNull<T>(this Assertions<T> assertions)
    {
        if (ReferenceEquals(assertions.Value, null))
        {
            throw new AssertionException("Value is null.");
        }

        return new AssertionsChain<T>(assertions);
    }
}