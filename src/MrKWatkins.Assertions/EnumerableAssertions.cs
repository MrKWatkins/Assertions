namespace MrKWatkins.Assertions;

public readonly ref struct EnumerableAssertions<TItem>
    where TItem : allows ref struct
{
    internal EnumerableAssertions([NoEnumeration] IEnumerable<TItem> value)
    {
        Value = value;
    }

    public IEnumerable<TItem> Value { get; }
}