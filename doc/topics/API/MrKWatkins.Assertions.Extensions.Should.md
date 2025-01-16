# Extensions.Should Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Should&lt;T&gt;(T)](MrKWatkins.Assertions.Extensions.Should.md#mrkwatkins-assertions-extensions-should-1(-0)) |  |
| [Should&lt;T&gt;(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.Extensions.Should.md#mrkwatkins-assertions-extensions-should-1(system-collections-generic-ienumerable((-0)))) |  |
| [Should&lt;T&gt;(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.Extensions.Should.md#mrkwatkins-assertions-extensions-should-1(system-readonlyspan((-0)))) |  |

## Should&lt;T&gt;(T) {id="mrkwatkins-assertions-extensions-should-1(-0)"}

```c#
public static ObjectAssertions<T> Should<T>(this T? value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-extensions-should-1(-0)"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-extensions-should-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T |  |

## Returns {id="returns-mrkwatkins-assertions-extensions-should-1(-0)"}

[ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.Assertions.ObjectAssertions-1.md)
## Should&lt;T&gt;(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-extensions-should-1(system-collections-generic-ienumerable((-0)))"}

```c#
public static EnumerableAssertions<T> Should<T>(this IEnumerable<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-extensions-should-1(system-collections-generic-ienumerable((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-extensions-should-1(system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) |  |

## Returns {id="returns-mrkwatkins-assertions-extensions-should-1(system-collections-generic-ienumerable((-0)))"}

[EnumerableAssertions&lt;T&gt;](MrKWatkins.Assertions.Assertions.EnumerableAssertions-1.md)
## Should&lt;T&gt;(ReadOnlySpan&lt;T&gt;) {id="mrkwatkins-assertions-extensions-should-1(system-readonlyspan((-0)))"}

```c#
public static ReadOnlySpanAssertions<T> Should<T>(this ReadOnlySpan<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-extensions-should-1(system-readonlyspan((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-extensions-should-1(system-readonlyspan((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ReadOnlySpan&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) |  |

## Returns {id="returns-mrkwatkins-assertions-extensions-should-1(system-readonlyspan((-0)))"}

[ReadOnlySpanAssertions&lt;T&gt;](MrKWatkins.Assertions.Assertions.ReadOnlySpanAssertions-1.md)
