# SequenceEqualExtensions.SequenceEqual Method
## Definition

```c#
public static ObjectAssertionsChain<TEnumerable> SequenceEqual<TEnumerable, T>(this ObjectAssertions<TEnumerable> assertions, params IEnumerable<T> expected)
   where TEnumerable : IEnumerable<T>;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TEnumerable |  |
| T |  |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TEnumerable&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |
| expected | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) |  |

## Returns

[ObjectAssertionsChain&lt;TEnumerable&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
