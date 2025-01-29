namespace MrKWatkins.Assertions;

public readonly ref struct ReadOnlySpanAssertionsChain<TItem>(ReadOnlySpanAssertions<TItem> assertions)
{
    public ReadOnlySpanAssertions<TItem> And { get; } = assertions;

    public ReadOnlySpan<TItem> Value => And.Value;
}