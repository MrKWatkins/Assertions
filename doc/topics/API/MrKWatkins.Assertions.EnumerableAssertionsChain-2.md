# EnumerableAssertionsChain&lt;TEnumerable, T&gt; Struct
## Definition

Enables chaining of assertions on an enumerable value after a successful assertion.

```c#
public sealed struct EnumerableAssertionsChain<TEnumerable, T>
   where TEnumerable : IEnumerable<T>
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TEnumerable | The type of the enumerable being asserted on. |
| T | The type of elements in the enumerable. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [EnumerableAssertionsChain(EnumerableAssertions&lt;TEnumerable, T&gt;)](MrKWatkins.Assertions.EnumerableAssertionsChain-2.-ctor.md) | Enables chaining of assertions on an enumerable value after a successful assertion. |

## Properties

| Name | Description |
| ---- | ----------- |
| [And](MrKWatkins.Assertions.EnumerableAssertionsChain-2.And.md) | Gets the assertions object for chaining further assertions. |
| [Value](MrKWatkins.Assertions.EnumerableAssertionsChain-2.Value.md) | Gets the enumerable value being asserted on. |

