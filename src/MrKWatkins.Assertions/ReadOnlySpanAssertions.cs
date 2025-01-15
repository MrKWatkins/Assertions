namespace MrKWatkins.Assertions;

public readonly ref struct ReadOnlySpanAssertions<TItem>
{
    internal ReadOnlySpanAssertions(ReadOnlySpan<TItem> value)
    {
        Value = value;
    }

    public ReadOnlySpan<TItem> Value { get; }
}