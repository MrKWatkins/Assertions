# CountExtensions.NotHaveCount Method
## Definition

Asserts that the enumerable does not have the specified number of elements.

```c#
public static ObjectAssertionsChain<T> NotHaveCount<T>(this ObjectAssertions<T> assertions, int expectedCount)
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
| expectedCount | [Int32](https://learn.microsoft.com/en-gb/dotnet/api/System.Int32) | The number of elements that is not expected. |

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for chaining further assertions.
