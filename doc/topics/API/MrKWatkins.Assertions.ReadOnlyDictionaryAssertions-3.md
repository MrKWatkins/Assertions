# ReadOnlyDictionaryAssertions&lt;TDictionary, TKey, TValue&gt; Class
## Definition

Provides assertions for read-only dictionary values.

```c#
public sealed class ReadOnlyDictionaryAssertions<TDictionary, TKey, TValue> : ObjectAssertions<TDictionary>
   where TDictionary : IReadOnlyDictionary<TKey, TValue>
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TDictionary | The type of the dictionary being asserted on. |
| TKey | The type of the dictionary keys. |
| TValue | The type of the dictionary values. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [ReadOnlyDictionaryAssertions(TDictionary)](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.-ctor.md) | Provides assertions for read-only dictionary values. |

## Methods

| Name | Description |
| ---- | ----------- |
| [ContainKey(TKey)](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.ContainKey.md) | Asserts that the dictionary contains the specified key. |
| [NotContainKey(TKey)](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.NotContainKey.md) | Asserts that the dictionary does not contain the specified key. |

