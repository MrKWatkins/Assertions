# ExceptionExtensions.HaveParamName Method
## Definition

```c#
public static ObjectAssertionsChain<TException> HaveParamName<TException>(this ObjectAssertions<TException> assertions, string expected)
   where TException : ArgumentException;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |
| expected | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) |  |

## Returns

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
