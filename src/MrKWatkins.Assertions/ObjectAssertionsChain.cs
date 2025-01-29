namespace MrKWatkins.Assertions;

public readonly struct ObjectAssertionsChain<T>(ObjectAssertions<T> objectAssertions)
{
    public ObjectAssertions<T> And => objectAssertions;

    public T That => And.Value;

    public T Value => And.Value;
}