namespace MrKWatkins.Assertions;

public readonly ref struct ReadOnlySpanAssertions<T>
{
    internal ReadOnlySpanAssertions(ReadOnlySpan<T> value)
    {
        Value = value;
    }

    public ReadOnlySpan<T> Value { get; }

    public ReadOnlySpanAssertionsChain<T> BeEmpty()
    {
        Verify.That(Value.IsEmpty, "Value should be empty but contained {0} elements.", Value.Length);

        return new ReadOnlySpanAssertionsChain<T>(this);
    }

    public ReadOnlySpanAssertionsChain<T> NotBeEmpty()
    {
        Verify.That(!Value.IsEmpty, "Value should not be empty.");

        return new ReadOnlySpanAssertionsChain<T>(this);
    }
}