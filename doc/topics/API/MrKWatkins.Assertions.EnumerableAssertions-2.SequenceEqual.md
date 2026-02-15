# EnumerableAssertions&lt;TEnumerable, T&gt;.SequenceEqual Method
## Definition

Asserts that the enumerable is sequence equal to the expected elements.

```c#
public EnumerableAssertionsChain<TEnumerable, T> SequenceEqual(params IEnumerable<T> expected);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) | The expected elements. |

## Returns

[EnumerableAssertionsChain&lt;TEnumerable, T&gt;](MrKWatkins.Assertions.EnumerableAssertionsChain-2.md)

An [EnumerableAssertionsChain&lt;TEnumerable, T&gt;](MrKWatkins.Assertions.EnumerableAssertionsChain-2.md) for chaining further assertions.
