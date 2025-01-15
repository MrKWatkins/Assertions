namespace MrKWatkins.Assertions;

public static class EnumerableAssertionsExtensions
{
    public static EnumerableAssertionsChain<TItem> BeNull<TItem>(this EnumerableAssertions<TItem> assertions)
    {
        Verify.That(ReferenceEquals(assertions.Value, null), "Value should {0}be null.", assertions.IsNot);

        return new EnumerableAssertionsChain<TItem>(assertions);
    }

    public static EnumerableAssertionsChain<TItem> BeEmpty<TItem>(this EnumerableAssertions<TItem> assertions)
    {
        assertions.Value.Should().Not.BeNull();
        Verify.That(!assertions.Value.Any(), "Value should {0}be empty.", assertions.IsNot);

        return new EnumerableAssertionsChain<TItem>(assertions);
    }
}