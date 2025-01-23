namespace MrKWatkins.Assertions;

public readonly struct EnumerableAssertionsChain<T>
{
    internal EnumerableAssertionsChain(EnumerableAssertions<T> enumerableAssertions)
    {
        And = enumerableAssertions;
    }

    public EnumerableAssertions<T> And { get; }

    public IEnumerable<T> Value => And.Value;
}