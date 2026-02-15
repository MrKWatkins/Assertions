# InvokingExtensions.Invoking Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Invoking&lt;T&gt;(T, Action&lt;T&gt;)](MrKWatkins.Assertions.InvokingExtensions.Invoking.md#mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))) | Wraps an action on the specified value for assertion testing. |
| [Invoking&lt;T, TResult&gt;(T, Func&lt;T, TResult&gt;)](MrKWatkins.Assertions.InvokingExtensions.Invoking.md#mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))) | Wraps a function on the specified value as an action for assertion testing, discarding the return value. |

## Invoking&lt;T&gt;(T, Action&lt;T&gt;) {id="mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

Wraps an action on the specified value for assertion testing.

```c#
public static Action Invoking<T>(this T? value, Action<T> action);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

| Name | Description |
| ---- | ----------- |
| T | The type of the value. |

## Parameters {id="parameters-mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T | The value to pass to the action. |
| action | [Action&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Action-1) | The action to test. |

## Returns {id="returns-mrkwatkins-assertions-invokingextensions-invoking-1(-0-system-action((-0)))"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)

An action that invokes the specified action with the value, for use with [Should(Action)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-action)).
## Invoking&lt;T, TResult&gt;(T, Func&lt;T, TResult&gt;) {id="mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

Wraps a function on the specified value as an action for assertion testing, discarding the return value.

```c#
public static Action Invoking<T, TResult>(this T? value, Func<T, TResult> action);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

| Name | Description |
| ---- | ----------- |
| T | The type of the value. |
| TResult | The return type of the function. |

## Parameters {id="parameters-mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T | The value to pass to the function. |
| action | [Func&lt;T, TResult&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Func-2) | The function to test. |

## Returns {id="returns-mrkwatkins-assertions-invokingextensions-invoking-2(-0-system-func((-0-1)))"}

[Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action)

An action that invokes the specified function with the value, for use with [Should(Action)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-action)).
