namespace MrKWatkins.Assertions;

public readonly struct ObjectAssertionsChain<T>
{
    internal ObjectAssertionsChain(ObjectAssertions<T> objectAssertions)
    {
        And = objectAssertions;
    }

    public ObjectAssertions<T> And { get; }

    public T Value => And.Value;
}