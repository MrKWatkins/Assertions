# StringAssertions.StartWith Method
## Definition

Asserts that the string starts with the specified value.

```c#
public StringAssertionsChain StartWith(string expected, StringComparison comparison = StringComparison.System.StringComparison);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected start of the string. |
| comparison | [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) | The [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) to use. Defaults to [Ordinal](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison#fields). |

## Returns

[StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md)

A [StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md) for chaining further assertions.
