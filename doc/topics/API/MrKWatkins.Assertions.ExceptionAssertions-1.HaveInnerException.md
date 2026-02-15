# ExceptionAssertions&lt;T&gt;.HaveInnerException Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [HaveInnerException&lt;TException&gt;()](MrKWatkins.Assertions.ExceptionAssertions-1.HaveInnerException.md#mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1) | Asserts that the exception has an inner exception of the specified type. |
| [HaveInnerException&lt;TException&gt;(TException)](MrKWatkins.Assertions.ExceptionAssertions-1.HaveInnerException.md#mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1(-0)) | Asserts that the exception has the exact specified inner exception instance. |

## HaveInnerException&lt;TException&gt;() {id="mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1"}

Asserts that the exception has an inner exception of the specified type.

```c#
public InnerExceptionAssertionsChain<TException> HaveInnerException<TException>()
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1"}

| Name | Description |
| ---- | ----------- |
| TException | The expected inner exception type. |

## Returns {id="returns-mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1"}

[InnerExceptionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.InnerExceptionAssertionsChain-1.md)

An [InnerExceptionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.InnerExceptionAssertionsChain-1.md) for asserting on the inner exception.
## HaveInnerException&lt;TException&gt;(TException) {id="mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1(-0)"}

Asserts that the exception has the exact specified inner exception instance.

```c#
public InnerExceptionAssertionsChain<TException> HaveInnerException<TException>(TException expected)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1(-0)"}

| Name | Description |
| ---- | ----------- |
| TException | The expected inner exception type. |

## Parameters {id="parameters-mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | TException | The expected inner exception instance. |

## Returns {id="returns-mrkwatkins-assertions-exceptionassertions-1-haveinnerexception-1(-0)"}

[InnerExceptionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.InnerExceptionAssertionsChain-1.md)

An [InnerExceptionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.InnerExceptionAssertionsChain-1.md) for asserting on the inner exception.
