namespace MrKWatkins.Assertions;

public static class ReadOnlySpanAssertionsExtensions
{
    public static ReadOnlySpanAssertionsChain<TItem> NotBeEmpty<TItem>(this ReadOnlySpanAssertions<TItem> assertions)
    {
        if (assertions.Value.IsEmpty)
        {
            throw new AssertionException("Value should not be empty.");
        }

        return new ReadOnlySpanAssertionsChain<TItem>(assertions);
    }

    public static ReadOnlySpanAssertionsChain<TItem> BeEmpty<TItem>(this ReadOnlySpanAssertions<TItem> assertions)
    {
        if (!assertions.Value.IsEmpty)
        {
            throw new AssertionException("Value should not be empty.");
        }

        return new ReadOnlySpanAssertionsChain<TItem>(assertions);
    }
}