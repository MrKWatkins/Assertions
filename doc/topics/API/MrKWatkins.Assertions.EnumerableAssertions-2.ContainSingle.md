# EnumerableAssertions&lt;TEnumerable, T&gt;.ContainSingle Method
## Definition

Asserts that the enumerable contains exactly one item that satisfies the specified predicate.

```c#
public ObjectAssertionsChain<T> ContainSingle(Func<T, bool> predicate, string? predicateExpression = null);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [Func&lt;T, Boolean&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Func-2) | The predicate to match. |
| predicateExpression | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expression text of the predicate, captured automatically. |

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for the single matching item.
