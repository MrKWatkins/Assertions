# Dictionaries

[`ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue>`](API/MrKWatkins.Assertions/ReadOnlyDictionaryAssertions-TDictionary-TKey-TValue/index.md) is available for [`IReadOnlyDictionary<TKey, TValue>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2) and [`Dictionary<TKey, TValue>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) via `.Should()`.

## Key Presence

```csharp
var dict = new Dictionary<string, int>
{
    ["one"] = 1,
    ["two"] = 2
};

dict.Should().ContainKey("one");
dict.Should().NotContainKey("three");
```

See [`ContainKey`](API/MrKWatkins.Assertions/ReadOnlyDictionaryAssertions-TDictionary-TKey-TValue/ContainKey.md) and [`NotContainKey`](API/MrKWatkins.Assertions/ReadOnlyDictionaryAssertions-TDictionary-TKey-TValue/NotContainKey.md).

## Chaining

Chainable methods return a [`ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>`](API/MrKWatkins.Assertions/ReadOnlyDictionaryAssertionsChain-TDictionary-TKey-TValue/index.md):

```csharp
dict.Should()
    .ContainKey("one")
    .And.ContainKey("two")
    .And.NotContainKey("three");
```

All object-level assertions are also available:

```csharp
Dictionary<string, int>? maybeNull = GetDict();
maybeNull.Should().NotBeNull().And.ContainKey("key");
```
