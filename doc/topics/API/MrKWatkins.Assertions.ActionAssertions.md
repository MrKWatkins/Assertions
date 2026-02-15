# ActionAssertions Class
## Definition

Provides assertions for actions, such as verifying that exceptions are thrown.

```c#
public sealed class ActionAssertions
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [ActionAssertions(Action)](MrKWatkins.Assertions.ActionAssertions.-ctor.md) | Provides assertions for actions, such as verifying that exceptions are thrown. |

## Methods

| Name | Description |
| ---- | ----------- |
| [NotThrow()](MrKWatkins.Assertions.ActionAssertions.NotThrow.md) | Asserts that the action does not throw any exception. |
| [Throw&lt;TException&gt;()](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1) | Asserts that the action throws an exception of the specified type. |
| [Throw&lt;TException&gt;(String)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(system-string)) | Asserts that the action throws an exception of the specified type with the specified message. |
| [Throw&lt;TException&gt;(String, Exception)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)) | Asserts that the action throws an exception of the specified type with the specified message and inner exception. |
| [Throw&lt;TException&gt;(TException)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(-0)) | Asserts that the action throws the exact specified exception instance. |
| [ThrowArgumentException(String, String)](MrKWatkins.Assertions.ActionAssertions.ThrowArgumentException.md) | Asserts that the action throws an [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException) with the specified message and parameter name. |
| [ThrowArgumentOutOfRangeException(String, String, Object)](MrKWatkins.Assertions.ActionAssertions.ThrowArgumentOutOfRangeException.md) | Asserts that the action throws an [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException) with the specified message, parameter name and actual value. |

