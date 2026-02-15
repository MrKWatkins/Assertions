# StringAssertions.NotEndWith Method
## Definition

Asserts that the string does not end with the specified value.

```c#
public StringAssertionsChain NotEndWith(string expected, StringComparison comparison = StringComparison.System.StringComparison);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The value the string should not end with. |
| comparison | [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) | The [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) to use. Defaults to [Ordinal](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison#fields). |

## Returns

[StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md)

A [StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md) for chaining further assertions.
