# ExceptionAssertions&lt;T&gt; Class
## Definition

Provides assertions for exception values.

```c#
public sealed class ExceptionAssertions<T> : ObjectAssertions<T>
   where T : Exception
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The type of the exception being asserted on. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [ExceptionAssertions(T)](MrKWatkins.Assertions.ExceptionAssertions-1.-ctor.md) | Provides assertions for exception values. |

## Methods

| Name | Description |
| ---- | ----------- |
| [HaveInnerException&lt;TException&gt;()](MrKWatkins.Assertions.ExceptionAssertions-1.HaveInnerException.md#mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1) | Asserts that the exception has an inner exception of the specified type. |
| [HaveInnerException&lt;TException&gt;(TException)](MrKWatkins.Assertions.ExceptionAssertions-1.HaveInnerException.md#mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1(-0)) | Asserts that the exception has the exact specified inner exception instance. |
| [HaveMessage(String)](MrKWatkins.Assertions.ExceptionAssertions-1.HaveMessage.md) | Asserts that the exception has the specified message. |
| [HaveMessageStartingWith(String)](MrKWatkins.Assertions.ExceptionAssertions-1.HaveMessageStartingWith.md) | Asserts that the exception message starts with the specified string. |
| [NotHaveInnerException()](MrKWatkins.Assertions.ExceptionAssertions-1.NotHaveInnerException.md) | Asserts that the exception does not have an inner exception. |
| [NotHaveMessage(String)](MrKWatkins.Assertions.ExceptionAssertions-1.NotHaveMessage.md) | Asserts that the exception does not have the specified message. |
| [NotHaveMessageStartingWith(String)](MrKWatkins.Assertions.ExceptionAssertions-1.NotHaveMessageStartingWith.md) | Asserts that the exception message does not start with the specified string. |

