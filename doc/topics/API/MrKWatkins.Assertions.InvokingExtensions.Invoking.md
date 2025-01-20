# InvokingExtensions.Invoking Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Invoking&lt;T&gt;(T, Action&lt;T&gt;)](MrKWatkins.Assertions.InvokingExtensions.Invoking.md#mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))) |  |
| [Invoking&lt;T, TResult&gt;(T, Func&lt;T, TResult&gt;)](MrKWatkins.Assertions.InvokingExtensions.Invoking.md#mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))) |  |

## Invoking&lt;T&gt;(T, Action&lt;T&gt;) {id="mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

```c#
public static Action Invoking<T>(this T? value, Action<T> action);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T |  |
| action | [Action&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Action-1) |  |

## Returns {id="returns-mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)
## Invoking&lt;T, TResult&gt;(T, Func&lt;T, TResult&gt;) {id="mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

```c#
public static Action Invoking<T, TResult>(this T? value, Func<T, TResult> action);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

| Name | Description |
| ---- | ----------- |
| T |  |
| TResult |  |

## Parameters {id="parameters-mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T |  |
| action | [Func&lt;T, TResult&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Func-2) |  |

## Returns {id="returns-mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)
