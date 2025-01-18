namespace MrKWatkins.Assertions;

public readonly struct ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>
    where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
    internal ReadOnlyDictionaryAssertionsChain(ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> assertions)
    {
        And = assertions;
    }

    public ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> And { get; }

    public TDictionary Value => And.Value;
}