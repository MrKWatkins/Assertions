# EnumerableExtensions.NotSequenceEqual Method
## Definition

Asserts that the non-generic enumerable is not sequence equal to the expected elements.

```c#
public static ObjectAssertionsChain<T> NotSequenceEqual<T>(this ObjectAssertions<T> assertions, params IEnumerable<object> expected)
   where T : IEnumerable;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The type of the enumerable. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) | The assertions object. |
| expected | [IEnumerable&lt;Object&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) | The elements the enumerable should not be sequence equal to. |

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for chaining further assertions.
