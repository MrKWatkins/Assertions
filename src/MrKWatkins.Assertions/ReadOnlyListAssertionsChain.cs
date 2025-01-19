namespace MrKWatkins.Assertions;

public readonly struct ReadOnlyListAssertionsChain<TList, T>
    where TList : IReadOnlyList<T>
{
    internal ReadOnlyListAssertionsChain(ReadOnlyListAssertions<TList, T> assertions)
    {
        And = assertions;
    }

    public ReadOnlyListAssertions<TList, T> And { get; }

    public TList Value => And.Value;
}