namespace MrKWatkins.Assertions;

public readonly ref struct AssertionsChain<T>
    where T : allows ref struct
{
    internal AssertionsChain(Assertions<T> assertions)
    {
        And = assertions;
    }

    public Assertions<T> And { get; }

    public T Value => And.Value;
}