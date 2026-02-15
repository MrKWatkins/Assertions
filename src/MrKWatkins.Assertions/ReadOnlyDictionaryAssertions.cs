namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for read-only dictionary values.
/// </summary>
/// <typeparam name="TDictionary">The type of the dictionary being asserted on.</typeparam>
/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
/// <param name="value">The dictionary to assert on.</param>
public sealed class ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue>([NoEnumeration] TDictionary value) : ObjectAssertions<TDictionary>(value)
    where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
    /// <summary>
    /// Asserts that the dictionary contains the specified key.
    /// </summary>
    /// <param name="key">The key that should be present.</param>
    /// <returns>A <see cref="ReadOnlyDictionaryAssertionsChain{TDictionary, TKey, TValue}" /> for chaining further assertions.</returns>
    public ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue> ContainKey(TKey key)
    {
        NotBeNull();
        Verify.That(Value.ContainsKey(key), $"Value should contain key {key}.");

        return new ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(this);
    }

    /// <summary>
    /// Asserts that the dictionary does not contain the specified key.
    /// </summary>
    /// <param name="key">The key that should not be present.</param>
    /// <returns>A <see cref="ReadOnlyDictionaryAssertionsChain{TDictionary, TKey, TValue}" /> for chaining further assertions.</returns>
    public ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue> NotContainKey(TKey key)
    {
        NotBeNull();
        Verify.That(!Value.ContainsKey(key), $"Value should not contain key {key}.");

        return new ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(this);
    }
}