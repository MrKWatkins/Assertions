namespace MrKWatkins.Assertions.Assertions;

public readonly ref struct ObjectAssertions<T>
{
    internal ObjectAssertions(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public void BeNull()
    {
        Verify.That(Value is null, "Value should be null.");
    }

    public ObjectAssertionsChain<T> NotBeNull()
    {
        Verify.That(Value is not null, "Value should not be null.");

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<TOther> BeOfType<TOther>()
    {
        Verify.That(Value is not null, "Value should not be null.");
        Verify.That(Value!.GetType().IsAssignableTo(typeof(TOther)), $"Value should be of type {typeof(TOther)}.");

        return new ObjectAssertionsChain<TOther>(new ObjectAssertions<TOther>((TOther)(object)Value!));
    }

    public ObjectAssertionsChain<T> NotBeOfType<TOther>()
    {
        Verify.That(Value is not null, "Value should not be null.");
        Verify.That(!Value!.GetType().IsAssignableTo(typeof(TOther)), $"Value should not be of type {typeof(TOther)}.");

        return new ObjectAssertionsChain<T>(this);
    }
}