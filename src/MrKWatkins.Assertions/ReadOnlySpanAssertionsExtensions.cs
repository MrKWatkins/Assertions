namespace MrKWatkins.Assertions;

public static class ReadOnlySpanAssertionsExtensions
{
    public static ReadOnlySpanAssertionsChain<TItem> BeEmpty<TItem>(this ReadOnlySpanAssertions<TItem> assertions)
    {
        Verify.That(assertions.Value.IsEmpty, "Value should {0}be empty.", assertions.IsNot);

        return new ReadOnlySpanAssertionsChain<TItem>(assertions);
    }
}