# ExceptionExtensions.HaveActualValue Method
## Definition

Asserts that the [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException) has the specified actual value.

```c#
public static ObjectAssertionsChain<TException> HaveActualValue<TException>(this ObjectAssertions<TException> assertions, object expected)
   where TException : ArgumentOutOfRangeException;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException | The type of the exception. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) | The assertions object. |
| expected | [Object](https://learn.microsoft.com/en-gb/dotnet/api/System.Object) | The expected actual value. |

## Returns

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for chaining further assertions.
