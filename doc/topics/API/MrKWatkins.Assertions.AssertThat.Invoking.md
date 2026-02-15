# AssertThat.Invoking Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Invoking(Action)](MrKWatkins.Assertions.AssertThat.Invoking.md#mrkwatkins-assertions-assertthat-invoking(system-action)) | Wraps an action for assertion testing. |
| [Invoking&lt;TResult&gt;(Func&lt;TResult&gt;)](MrKWatkins.Assertions.AssertThat.Invoking.md#mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))) | Wraps a function as an action for assertion testing, discarding the return value. |

## Invoking(Action) {id="mrkwatkins-assertions-assertthat-invoking(system-action)"}

Wraps an action for assertion testing.

```c#
public static Action Invoking(Action action);
```

## Parameters {id="parameters-mrkwatkins-assertions-assertthat-invoking(system-action)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action) | The action to test. |

## Returns {id="returns-mrkwatkins-assertions-assertthat-invoking(system-action)"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)

The action, for use with [Should(Action)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-action)).
## Invoking&lt;TResult&gt;(Func&lt;TResult&gt;) {id="mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

Wraps a function as an action for assertion testing, discarding the return value.

```c#
public static Action Invoking<TResult>(Func<TResult> action);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

| Name | Description |
| ---- | ----------- |
| TResult | The return type of the function. |

## Parameters {id="parameters-mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Func&lt;TResult&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Func-1) | The function to test. |

## Returns {id="returns-mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)

An action that invokes the function, for use with [Should(Action)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-action)).
