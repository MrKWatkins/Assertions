namespace MrKWatkins.Assertions;

public readonly ref struct ObjectAssertionsChain<T>
    where T : allows ref struct
{
    internal ObjectAssertionsChain(ObjectAssertions<T> objectAssertions)
    {
        And = objectAssertions;
    }

    public ObjectAssertions<T> And { get; }

    public T Value => And.Value;
}