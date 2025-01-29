namespace MrKWatkins.Assertions;

public readonly struct ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> assertions)
    where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
    public ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> And { get; } = assertions;

    public TDictionary Value => And.Value;
}