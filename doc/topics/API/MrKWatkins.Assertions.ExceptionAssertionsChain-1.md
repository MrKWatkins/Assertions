# ExceptionAssertionsChain&lt;T&gt; Struct
## Definition

Enables chaining of assertions on an exception value after a successful assertion.

```c#
public sealed struct ExceptionAssertionsChain<T>
   where T : Exception
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The type of the exception being asserted on. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [ExceptionAssertionsChain(ExceptionAssertions&lt;T&gt;)](MrKWatkins.Assertions.ExceptionAssertionsChain-1.-ctor.md) | Enables chaining of assertions on an exception value after a successful assertion. |

## Properties

| Name | Description |
| ---- | ----------- |
| [And](MrKWatkins.Assertions.ExceptionAssertionsChain-1.And.md) | Gets the assertions object for chaining further assertions. |
| [Value](MrKWatkins.Assertions.ExceptionAssertionsChain-1.Value.md) | Gets the exception value being asserted on. |

