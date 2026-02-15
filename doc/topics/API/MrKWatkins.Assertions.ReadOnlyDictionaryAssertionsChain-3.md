# ReadOnlyDictionaryAssertionsChain&lt;TDictionary, TKey, TValue&gt; Struct
## Definition

Enables chaining of assertions on a read-only dictionary value after a successful assertion.

```c#
public sealed struct ReadOnlyDictionaryAssertionsChain<TDictionary, TKey, TValue>
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
| [ReadOnlyDictionaryAssertionsChain(ReadOnlyDictionaryAssertions&lt;TDictionary, TKey, TValue&gt;)](MrKWatkins.Assertions.ReadOnlyDictionaryAssertionsChain-3.-ctor.md) | Enables chaining of assertions on a read-only dictionary value after a successful assertion. |

## Properties

| Name | Description |
| ---- | ----------- |
| [And](MrKWatkins.Assertions.ReadOnlyDictionaryAssertionsChain-3.And.md) | Gets the assertions object for chaining further assertions. |
| [Value](MrKWatkins.Assertions.ReadOnlyDictionaryAssertionsChain-3.Value.md) | Gets the dictionary value being asserted on. |

