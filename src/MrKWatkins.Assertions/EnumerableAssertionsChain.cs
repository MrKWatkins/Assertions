namespace MrKWatkins.Assertions;

public readonly struct EnumerableAssertionsChain<TEnumerable, T>(EnumerableAssertions<TEnumerable, T> enumerableAssertions)
    where TEnumerable : IEnumerable<T>
{
    public EnumerableAssertions<TEnumerable, T> And { get; } = enumerableAssertions;

    public TEnumerable Value => And.Value;
}