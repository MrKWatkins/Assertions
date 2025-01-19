namespace MrKWatkins.Assertions;

public sealed class ReadOnlyListAssertions<TList, T> : ObjectAssertions<TList>
    where TList : IReadOnlyList<T>
{
    internal ReadOnlyListAssertions(TList? value)
        : base(value)
    {
    }
}