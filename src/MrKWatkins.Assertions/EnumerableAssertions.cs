namespace MrKWatkins.Assertions;

public readonly ref struct EnumerableAssertions<TItem>
    where TItem : allows ref struct
{
    internal EnumerableAssertions([NoEnumeration] IEnumerable<TItem> value, bool isNot = false)
    {
        Value = value;
        IsNot = isNot;
    }

    public IEnumerable<TItem> Value { get; }

    internal bool IsNot { get; }

    public EnumerableAssertions<TItem> Not => new(Value, !IsNot);
}