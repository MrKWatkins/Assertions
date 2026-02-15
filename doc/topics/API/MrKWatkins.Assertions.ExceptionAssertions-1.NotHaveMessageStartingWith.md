# ExceptionAssertions&lt;T&gt;.NotHaveMessageStartingWith Method
## Definition

Asserts that the exception message does not start with the specified string.

```c#
public ExceptionAssertionsChain<T> NotHaveMessageStartingWith(string expected);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The message prefix that is not expected. |

## Returns

[ExceptionAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ExceptionAssertionsChain-1.md)

An [ExceptionAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ExceptionAssertionsChain-1.md) for chaining further assertions.
