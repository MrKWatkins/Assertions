# StringAssertions.NotContain Method
## Definition

Asserts that the string does not contain the specified substring.

```c#
public StringAssertionsChain NotContain(string expected, StringComparison comparison = StringComparison.System.StringComparison);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The substring that should not be present. |
| comparison | [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) | The [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) to use. Defaults to [Ordinal](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison#fields). |

## Returns

[StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md)

A [StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md) for chaining further assertions.
