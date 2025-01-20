# AssertThat.Invoking Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Invoking(Action)](MrKWatkins.Assertions.AssertThat.Invoking.md#mrkwatkins-assertions-assertthat-invoking(system-action)) |  |
| [Invoking&lt;TResult&gt;(Func&lt;TResult&gt;)](MrKWatkins.Assertions.AssertThat.Invoking.md#mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))) |  |

## Invoking(Action) {id="mrkwatkins-assertions-assertthat-invoking(system-action)"}

```c#
public static Action Invoking(Action action);
```

## Parameters {id="parameters-mrkwatkins-assertions-assertthat-invoking(system-action)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action) |  |

## Returns {id="returns-mrkwatkins-assertions-assertthat-invoking(system-action)"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)
## Invoking&lt;TResult&gt;(Func&lt;TResult&gt;) {id="mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

```c#
public static Action Invoking<TResult>(Func<TResult> action);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

| Name | Description |
| ---- | ----------- |
| TResult |  |

## Parameters {id="parameters-mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Func&lt;TResult&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Func-1) |  |

## Returns {id="returns-mrkwatkins-assertions-assertthat-invoking-1(system-func((-0)))"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)
