# ActionAssertions.ThrowArgumentOutOfRangeException Method
## Definition

Asserts that the action throws an [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException) with the specified message, parameter name and actual value.

```c#
public ActionAssertionsChain<ArgumentOutOfRangeException> ThrowArgumentOutOfRangeException(string expectedMessage, string expectedParamName, object expectedActualValue);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected exception message. |
| expectedParamName | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected parameter name. |
| expectedActualValue | [Object](https://learn.microsoft.com/en-gb/dotnet/api/System.Object) | The expected actual value. |

## Returns

[ActionAssertionsChain&lt;ArgumentOutOfRangeException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)

An [ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md) containing the thrown exception.
