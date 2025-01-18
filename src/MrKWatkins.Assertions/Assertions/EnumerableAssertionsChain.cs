namespace MrKWatkins.Assertions.Assertions;

public readonly struct EnumerableAssertionsChain<TItem>
{
    internal EnumerableAssertionsChain(EnumerableAssertions<TItem> assertions)
    {
        And = assertions;
    }

    public EnumerableAssertions<TItem> And { get; }

    public IEnumerable<TItem> Value => And.Value;
}