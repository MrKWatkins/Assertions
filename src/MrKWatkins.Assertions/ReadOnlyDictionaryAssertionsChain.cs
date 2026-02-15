namespace MrKWatkins.Assertions;

/// <summary>
/// Enables chaining of assertions on a read-only dictionary value after a successful assertion.
/// </summary>
/// <typeparam name="TDictionary">The type of the dictionary being asserted on.</typeparam>
/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
/// <param name="assertions">The assertions object to chain from.</param>
public readonly struct ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>(ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> assertions)
    where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
    /// <summary>
    /// Gets the assertions object for chaining further assertions.
    /// </summary>
    public ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> And { get; } = assertions;

    /// <summary>
    /// Gets the dictionary value being asserted on.
    /// </summary>
    public TDictionary Value => And.Value;
}