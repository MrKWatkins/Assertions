namespace MrKWatkins.Assertions;

public class EnumerableAssertions<TEnumerable, T> : ObjectAssertions<TEnumerable>
    where TEnumerable : IEnumerable<T>
{
    internal EnumerableAssertions([NoEnumeration] TEnumerable? value)
        : base(value)
    {
    }

    public EnumerableAssertionsChain<TEnumerable, T> BeEmpty()
    {
        NotBeNull();
        Verify.That(!Value.Any(), "Value should be empty but has {0} items.", Value.Count);

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }

    public EnumerableAssertionsChain<TEnumerable, T> NotBeEmpty()
    {
        NotBeNull();
        Verify.That(Value.Any(), "Value should not be empty.");

        return new EnumerableAssertionsChain<TEnumerable, T>(this);
    }
}