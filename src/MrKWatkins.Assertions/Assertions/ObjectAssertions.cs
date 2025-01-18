namespace MrKWatkins.Assertions.Assertions;

public readonly struct ObjectAssertions<T>
{
    internal ObjectAssertions(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public void BeNull()
    {
        Verify.That(Value is null, "Value should be null but was {0}.", Value);
    }

    public ObjectAssertionsChain<T> NotBeNull()
    {
        Verify.That(Value is not null, "Value should not be null.");

        return new ObjectAssertionsChain<T>(this);
    }

    public ObjectAssertionsChain<TOther> BeOfType<TOther>()
    {
        Verify.That(Value is not null, "Value should not be null.");

        var type = Value!.GetType();
        Verify.That(type.IsAssignableTo(typeof(TOther)), "Value should be of type {0} but was of type {1}.", typeof(TOther), type);

        return new ObjectAssertionsChain<TOther>(new ObjectAssertions<TOther>((TOther)(object)Value!));
    }

    public ObjectAssertionsChain<T> NotBeOfType<TOther>()
    {
        Verify.That(Value is not null, "Value should not be null.");

        var type = Value!.GetType();
        Verify.That(!type.IsAssignableTo(typeof(TOther)), "Value should not be of type {0}.", type);

        return new ObjectAssertionsChain<T>(this);
    }
}