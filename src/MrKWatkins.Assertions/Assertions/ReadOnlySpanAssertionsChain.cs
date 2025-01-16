namespace MrKWatkins.Assertions.Assertions;

public readonly ref struct ReadOnlySpanAssertionsChain<TItem>
{
    internal ReadOnlySpanAssertionsChain(ReadOnlySpanAssertions<TItem> assertions)
    {
        And = assertions;
    }

    public ReadOnlySpanAssertions<TItem> And { get; }

    public ReadOnlySpan<TItem> Value => And.Value;
}