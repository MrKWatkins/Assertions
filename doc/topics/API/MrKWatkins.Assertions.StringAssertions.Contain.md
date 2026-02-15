# StringAssertions.Contain Method
## Definition

Asserts that the string contains the specified substring.

```c#
public StringAssertionsChain Contain(string expected, StringComparison comparison = StringComparison.System.StringComparison);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected substring. |
| comparison | [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) | The [StringComparison](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison) to use. Defaults to [Ordinal](https://learn.microsoft.com/en-gb/dotnet/api/System.StringComparison#fields). |

## Returns

[StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md)

A [StringAssertionsChain](MrKWatkins.Assertions.StringAssertionsChain.md) for chaining further assertions.
