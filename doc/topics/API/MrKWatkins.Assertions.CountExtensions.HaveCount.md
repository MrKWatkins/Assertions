# CountExtensions.HaveCount Method
## Definition

```c#
public static ObjectAssertionsChain<T> HaveCount<T>(this ObjectAssertions<T> assertions, int expectedCount)
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
| expectedCount | [Int32](https://learn.microsoft.com/en-gb/dotnet/api/System.Int32) |  |

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
