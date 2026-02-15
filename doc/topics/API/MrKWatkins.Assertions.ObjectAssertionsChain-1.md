# ObjectAssertionsChain&lt;T&gt; Struct
## Definition

Enables chaining of assertions on an object value after a successful assertion.

```c#
public sealed struct ObjectAssertionsChain<T>
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The type of the value being asserted on. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [ObjectAssertionsChain(ObjectAssertions&lt;T&gt;)](MrKWatkins.Assertions.ObjectAssertionsChain-1.-ctor.md) | Enables chaining of assertions on an object value after a successful assertion. |

## Properties

| Name | Description |
| ---- | ----------- |
| [And](MrKWatkins.Assertions.ObjectAssertionsChain-1.And.md) | Gets the assertions object for chaining further assertions. |
| [That](MrKWatkins.Assertions.ObjectAssertionsChain-1.That.md) | Gets the value being asserted on, for use in further assertions via `.Should()`. |
| [Value](MrKWatkins.Assertions.ObjectAssertionsChain-1.Value.md) | Gets the value being asserted on. |

