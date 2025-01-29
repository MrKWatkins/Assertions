# EnumerableExtensions.NotSequenceEqual Method
## Definition

```c#
public static ObjectAssertionsChain<T> NotSequenceEqual<T>(this ObjectAssertions<T> assertions, params IEnumerable<object> expected)
   where T : IEnumerable;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |
| expected | [IEnumerable&lt;Object&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) |  |

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
