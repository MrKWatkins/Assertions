# EnumerableAssertions&lt;TEnumerable, T&gt;.OnlyContain Method
## Definition

Asserts that all items in the enumerable satisfy the specified predicate.

```c#
public EnumerableAssertionsChain<TEnumerable, T> OnlyContain(Func<T, bool> predicate, string? predicateExpression = null);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [Func&lt;T, Boolean&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Func-2) | The predicate that all items must satisfy. |
| predicateExpression | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expression text of the predicate, captured automatically. |

## Returns

[EnumerableAssertionsChain&lt;TEnumerable, T&gt;](MrKWatkins.Assertions.EnumerableAssertionsChain-2.md)

An [EnumerableAssertionsChain&lt;TEnumerable, T&gt;](MrKWatkins.Assertions.EnumerableAssertionsChain-2.md) for chaining further assertions.
