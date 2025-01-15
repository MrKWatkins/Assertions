namespace MrKWatkins.Assertions;

public readonly ref struct ReadOnlySpanAssertions<TItem>
{
    internal ReadOnlySpanAssertions(ReadOnlySpan<TItem> value, bool isNot = false)
    {
        Value = value;
        IsNot = isNot;
    }

    public ReadOnlySpan<TItem> Value { get; }

    internal bool IsNot { get; }

    public ReadOnlySpanAssertions<TItem> Not => new(Value, !IsNot);
}