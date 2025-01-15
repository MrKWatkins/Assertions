namespace MrKWatkins.Assertions;

public static class EnumerableAssertionsExtensions
{
    public static EnumerableAssertionsChain<TItem> NotBeNull<TItem>(this EnumerableAssertions<TItem> assertions)
    {
        if (ReferenceEquals(assertions.Value, null))
        {
            throw new AssertionException("Value is null.");
        }

        return new EnumerableAssertionsChain<TItem>(assertions);
    }

    public static EnumerableAssertionsChain<TItem> NotBeEmpty<TItem>(this EnumerableAssertions<TItem> assertions)
    {
        assertions.NotBeNull();
        if (!assertions.Value.Any())
        {
            throw new AssertionException("Value should not be empty.");
        }

        return new EnumerableAssertionsChain<TItem>(assertions);
    }

    public static EnumerableAssertionsChain<TItem> BeEmpty<TItem>(this EnumerableAssertions<TItem> assertions)
    {
        assertions.NotBeNull();
        if (assertions.Value.Any())
        {
            throw new AssertionException("Value should not be empty.");
        }

        return new EnumerableAssertionsChain<TItem>(assertions);
    }
}