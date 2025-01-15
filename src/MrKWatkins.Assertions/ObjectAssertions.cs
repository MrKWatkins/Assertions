namespace MrKWatkins.Assertions;

public readonly ref struct ObjectAssertions<T>
    where T : allows ref struct
{
    internal ObjectAssertions(T value, bool isNot = false)
    {
        Value = value;
        IsNot = isNot;
    }

    public T Value { get; }

    internal bool IsNot { get; }

    public ObjectAssertions<T> Not => new(Value, !IsNot);
}