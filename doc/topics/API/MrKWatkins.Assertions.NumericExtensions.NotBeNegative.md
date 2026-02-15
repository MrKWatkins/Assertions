# NumericExtensions.NotBeNegative Method
## Definition

Asserts that the numeric value is not negative.

```c#
public static ObjectAssertionsChain<T> NotBeNegative<T>(this ObjectAssertions<T> assertions)
   where T : INumberBase<T>;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The numeric type. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) | The assertions object. |

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for chaining further assertions.
