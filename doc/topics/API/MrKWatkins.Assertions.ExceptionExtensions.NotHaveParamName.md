# ExceptionExtensions.NotHaveParamName Method
## Definition

Asserts that the [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException) does not have the specified parameter name.

```c#
public static ObjectAssertionsChain<TException> NotHaveParamName<TException>(this ObjectAssertions<TException> assertions, string expected)
   where TException : ArgumentException;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException | The type of the exception. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) | The assertions object. |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The parameter name that is not expected. |

## Returns

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)

An [ObjectAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md) for chaining further assertions.
