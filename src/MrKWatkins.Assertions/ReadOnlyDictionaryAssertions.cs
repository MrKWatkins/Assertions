namespace MrKWatkins.Assertions;

public sealed class ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> : EnumerableAssertions<TDictionary, KeyValuePair<TKey, TValue>>
    where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
    internal ReadOnlyDictionaryAssertions([NoEnumeration] TDictionary value)
        : base(value)
    {
    }

    public ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue> ContainKey(TKey key)
    {
        NotBeNull();
        Verify.That(Value.ContainsKey(key), "Value should contain key {0}.", key);

        return new ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(this);
    }

    public ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue> NotContainKey(TKey key)
    {
        NotBeNull();
        Verify.That(!Value.ContainsKey(key), "Value should not contain key {0}.", key);

        return new ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(this);
    }
}