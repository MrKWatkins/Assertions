# ActionAssertionsChain&lt;TException&gt; Struct
## Definition

Enables access to an exception thrown by an action after a successful throw assertion.

```c#
public sealed struct ActionAssertionsChain<TException>
   where TException : Exception
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TException | The type of the exception that was thrown. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [ActionAssertionsChain(TException)](MrKWatkins.Assertions.ActionAssertionsChain-1.-ctor.md) | Enables access to an exception thrown by an action after a successful throw assertion. |

## Properties

| Name | Description |
| ---- | ----------- |
| [Exception](MrKWatkins.Assertions.ActionAssertionsChain-1.Exception.md) | Gets the exception that was thrown. |
| [That](MrKWatkins.Assertions.ActionAssertionsChain-1.That.md) | Gets the exception that was thrown, for use in further assertions via `.Should()`. |

