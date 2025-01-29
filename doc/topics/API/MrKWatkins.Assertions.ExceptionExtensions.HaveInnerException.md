# ExceptionExtensions.HaveInnerException Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [HaveInnerException&lt;TException&gt;(ObjectAssertions&lt;TException&gt;)](MrKWatkins.Assertions.ExceptionExtensions.HaveInnerException.md#mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0)))) |  |
| [HaveInnerException&lt;TException&gt;(ObjectAssertions&lt;TException&gt;, Exception)](MrKWatkins.Assertions.ExceptionExtensions.HaveInnerException.md#mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0))-system-exception)) |  |

## HaveInnerException&lt;TException&gt;(ObjectAssertions&lt;TException&gt;) {id="mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0)))"}

```c#
public static ObjectAssertionsChain<TException> HaveInnerException<TException>(this ObjectAssertions<TException> assertions)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0)))"}

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters {id="parameters-mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |

## Returns {id="returns-mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0)))"}

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
## HaveInnerException&lt;TException&gt;(ObjectAssertions&lt;TException&gt;, Exception) {id="mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0))-system-exception)"}

```c#
public static ObjectAssertionsChain<TException> HaveInnerException<TException>(this ObjectAssertions<TException> assertions, Exception expected)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0))-system-exception)"}

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters {id="parameters-mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0))-system-exception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ObjectAssertions&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) |  |
| expected | [Exception](https://learn.microsoft.com/en-gb/dotnet/api/System.Exception) |  |

## Returns {id="returns-mrkwatkins-assertions-exceptionextensions-haveinnerexception-1(mrkwatkins-assertions-objectassertions((-0))-system-exception)"}

[ObjectAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ObjectAssertionsChain-1.md)
