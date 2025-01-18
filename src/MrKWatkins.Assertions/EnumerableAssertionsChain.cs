namespace MrKWatkins.Assertions;

public readonly struct EnumerableAssertionsChain<TEnumerable, T>
    where TEnumerable : IEnumerable<T>
{
    internal EnumerableAssertionsChain(EnumerableAssertions<TEnumerable, T> assertions)
    {
        And = assertions;
    }

    public EnumerableAssertions<TEnumerable, T> And { get; }

    public TEnumerable Value => And.Value;
}