# ExceptionExtensions.NotHaveInnerException Method
## Definition

```c#
public static ObjectAssertionsChain<TException> NotHaveInnerException<TException>(this ObjectAssertions<TException> assertions, Exception expected)
   where TException : Exception;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |
| expected | [Exception](https://learn.microsoft.com/en-gb/dotnet/api/System.Exception) |  |

## Returns

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
