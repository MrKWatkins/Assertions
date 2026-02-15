# ActionAssertions.ThrowArgumentException Method
## Definition

Asserts that the action throws an [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException) with the specified message and parameter name.

```c#
public ActionAssertionsChain<ArgumentException> ThrowArgumentException(string expectedMessage, string expectedParamName);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected exception message. |
| expectedParamName | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected parameter name. |

## Returns

[ActionAssertionsChain&lt;ArgumentException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)

An [ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md) containing the thrown exception.
