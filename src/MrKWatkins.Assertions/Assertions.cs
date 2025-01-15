namespace MrKWatkins.Assertions;

public readonly ref struct Assertions<T>
    where T : allows ref struct
{
    internal Assertions(T value)
    {
        Value = value;
    }

    public T Value { get; }
}