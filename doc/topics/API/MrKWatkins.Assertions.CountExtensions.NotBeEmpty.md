# CountExtensions.NotBeEmpty Method
## Definition

Asserts that the enumerable is not empty.

```c#
public static ObjectAssertionsChain<T> NotBeEmpty<T>(this ObjectAssertions<T> assertions)
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

## Returns

[ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for chaining further assertions.
