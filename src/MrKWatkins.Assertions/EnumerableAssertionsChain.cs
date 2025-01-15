namespace MrKWatkins.Assertions;

public readonly ref struct EnumerableAssertionsChain<TItem>
    where TItem : allows ref struct
{
    internal EnumerableAssertionsChain(EnumerableAssertions<TItem> assertions)
    {
        And = assertions;
    }

    public EnumerableAssertions<TItem> And { get; }

    public IEnumerable<TItem> Value => And.Value;
}