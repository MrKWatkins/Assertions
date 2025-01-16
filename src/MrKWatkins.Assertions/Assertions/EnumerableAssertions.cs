namespace MrKWatkins.Assertions.Assertions;

public readonly ref struct EnumerableAssertions<TItem>
{
    internal EnumerableAssertions([NoEnumeration] IEnumerable<TItem> value)
    {
        Value = value;
    }

    public IEnumerable<TItem> Value { get; }

    public void BeNull()
    {
        Verify.That(Value is null, "Value should be null but was {0}.", Value);
    }

    public EnumerableAssertionsChain<TItem> NotBeNull()
    {
        Verify.That(Value is not null, "Value should not be null.");

        return new EnumerableAssertionsChain<TItem>(this);
    }

    public EnumerableAssertionsChain<TItem> BeEmpty()
    {
        NotBeNull();
        Verify.That(!Value.Any(), "Value should be empty but has {0} items.", Value.Count());

        return new EnumerableAssertionsChain<TItem>(this);
    }

    public EnumerableAssertionsChain<TItem> NotBeEmpty()
    {
        NotBeNull();
        Verify.That(Value.Any(), "Value should not be empty.");

        return new EnumerableAssertionsChain<TItem>(this);
    }
}