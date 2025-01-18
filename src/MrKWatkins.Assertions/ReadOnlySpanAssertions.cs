namespace MrKWatkins.Assertions;

public readonly ref struct ReadOnlySpanAssertions<TItem>
{
    internal ReadOnlySpanAssertions(ReadOnlySpan<TItem> value)
    {
        Value = value;
    }

    public ReadOnlySpan<TItem> Value { get; }

    public ReadOnlySpanAssertionsChain<TItem> BeEmpty()
    {
        Verify.That(Value.IsEmpty, "Value should be empty but contained {0} elements.", Value.Length);

        return new ReadOnlySpanAssertionsChain<TItem>(this);
    }

    public ReadOnlySpanAssertionsChain<TItem> NotBeEmpty()
    {
        Verify.That(!Value.IsEmpty, "Value should not be empty.");

        return new ReadOnlySpanAssertionsChain<TItem>(this);
    }
}