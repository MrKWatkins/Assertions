# ShouldExtensions.Should Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Should&lt;T&gt;(T)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(-0)) |  |
| [Should(Exception)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-exception)) |  |
| [Should(ArgumentException)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-argumentexception)) |  |
| [Should(ArgumentOutOfRangeException)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)) |  |
| [Should&lt;T&gt;(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))) |  |
| [Should&lt;TKey, TValue&gt;(IReadOnlyDictionary&lt;TKey, TValue&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))) |  |
| [Should&lt;TKey, TValue&gt;(Dictionary&lt;TKey, TValue&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))) |  |
| [Should&lt;T&gt;(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))) |  |
| [Should(Action)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-action)) |  |

## Should&lt;T&gt;(T) {id="mrkwatkins-assertions-shouldextensions-should-1(-0)"}

```c#
public static ObjectAssertions<T> Should<T>(this T? value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(-0)"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(-0)"}

[ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md)
## Should(Exception) {id="mrkwatkins-assertions-shouldextensions-should(system-exception)"}

```c#
public static ExceptionAssertions<Exception> Should(this Exception? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-exception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Exception](https://learn.microsoft.com/en-gb/dotnet/api/System.Exception) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-exception)"}

[ExceptionAssertions&lt;Exception&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md)
## Should(ArgumentException) {id="mrkwatkins-assertions-shouldextensions-should(system-argumentexception)"}

```c#
public static ExceptionAssertions<ArgumentException> Should(this ArgumentException? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-argumentexception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-argumentexception)"}

[ExceptionAssertions&lt;ArgumentException&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md)
## Should(ArgumentOutOfRangeException) {id="mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)"}

```c#
public static ExceptionAssertions<ArgumentOutOfRangeException> Should(this ArgumentOutOfRangeException? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)"}

[ExceptionAssertions&lt;ArgumentOutOfRangeException&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md)
## Should&lt;T&gt;(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

```c#
public static EnumerableAssertions<IEnumerable<T>, T> Should<T>(this IEnumerable<T>? value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

[EnumerableAssertions&lt;IEnumerable&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
## Should&lt;TKey, TValue&gt;(IReadOnlyDictionary&lt;TKey, TValue&gt;) {id="mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

```c#
public static ReadOnlyDictionaryAssertions<IReadOnlyDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

| Name | Description |
| ---- | ----------- |
| TKey |  |
| TValue |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IReadOnlyDictionary&lt;TKey, TValue&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

[ReadOnlyDictionaryAssertions&lt;IReadOnlyDictionary&lt;TKey, TValue&gt;, TKey, TValue&gt;](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.md)
## Should&lt;TKey, TValue&gt;(Dictionary&lt;TKey, TValue&gt;) {id="mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

```c#
public static ReadOnlyDictionaryAssertions<Dictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>(this Dictionary<TKey, TValue> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

| Name | Description |
| ---- | ----------- |
| TKey |  |
| TValue |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Dictionary&lt;TKey, TValue&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.Dictionary-2) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

[ReadOnlyDictionaryAssertions&lt;Dictionary&lt;TKey, TValue&gt;, TKey, TValue&gt;](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.md)
## Should&lt;T&gt;(ReadOnlySpan&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

```c#
public static ReadOnlySpanAssertions<T> Should<T>(this ReadOnlySpan<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ReadOnlySpan&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

[ReadOnlySpanAssertions&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.md)
## Should(Action) {id="mrkwatkins-assertions-shouldextensions-should(system-action)"}

```c#
public static ActionAssertions Should(this Action value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-action)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-action)"}

[ActionAssertions](MrKWatkins.Assertions.ActionAssertions.md)
