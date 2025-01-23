# ExceptionExtensions.NotHaveActualValue Method
## Definition

```c#
public static ObjectAssertionsChain<TException> NotHaveActualValue<TException>(this ObjectAssertions<TException> assertions, object expected)
   where TException : ArgumentOutOfRangeException;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |
| expected | [Object](https://learn.microsoft.com/en-gb/dotnet/api/System.Object) |  |

## Returns

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
