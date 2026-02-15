# With.IntegerFormat Method
## Definition

Sets the display format for integer values in assertion messages within the returned scope.

```c#
public static IDisposable IntegerFormat(IntegerFormat format);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [IntegerFormat](MrKWatkins.Assertions.IntegerFormat.md) | The integer display format to use. |

## Returns

[IDisposable](https://learn.microsoft.com/en-gb/dotnet/api/System.IDisposable)

An [IDisposable](https://learn.microsoft.com/en-gb/dotnet/api/System.IDisposable) that restores the previous format when disposed.
