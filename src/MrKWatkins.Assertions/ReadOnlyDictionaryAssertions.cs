namespace MrKWatkins.Assertions;

public sealed class ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue>([NoEnumeration] TDictionary value) : ObjectAssertions<TDictionary>(value)
    where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
    public ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue> ContainKey(TKey key)
    {
        NotBeNull();
        Verify.That(Value.ContainsKey(key), $"Value should contain key {key}.");

        return new ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(this);
    }

    public ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue> NotContainKey(TKey key)
    {
        NotBeNull();
        Verify.That(!Value.ContainsKey(key), $"Value should not contain key {key}.");

        return new ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(this);
    }
}