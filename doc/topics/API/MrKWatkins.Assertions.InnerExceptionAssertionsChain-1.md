# InnerExceptionAssertionsChain&lt;TException&gt; Struct
## Definition

Enables further assertions on an inner exception after a successful inner exception assertion.

```c#
public sealed struct InnerExceptionAssertionsChain<TException>
   where TException : Exception
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException | The type of the inner exception. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [InnerExceptionAssertionsChain(TException)](MrKWatkins.Assertions.InnerExceptionAssertionsChain-1.-ctor.md) | Enables further assertions on an inner exception after a successful inner exception assertion. |

## Properties

| Name | Description |
| ---- | ----------- |
| [That](MrKWatkins.Assertions.InnerExceptionAssertionsChain-1.That.md) | Gets the inner exception, for use in further assertions via `.Should()`. |

