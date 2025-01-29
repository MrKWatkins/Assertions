namespace MrKWatkins.Assertions;

public readonly struct ObjectAssertionsChain<T>(ObjectAssertions<T> objectAssertions)
{
    public ObjectAssertions<T> And { get; } = objectAssertions;

    public T Value => And.Value;
}