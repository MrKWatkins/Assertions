# ShouldExtensions.Should Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Should&lt;T&gt;(T)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(-0)) | Begins a fluent assertion on the specified value. |
| [Should(String)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-string)) | Begins a fluent assertion on the specified string value. |
| [Should(Exception)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-exception)) | Begins a fluent assertion on the specified exception. |
| [Should(ArgumentException)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-argumentexception)) | Begins a fluent assertion on the specified [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException). |
| [Should(ArgumentOutOfRangeException)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)) | Begins a fluent assertion on the specified [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException). |
| [Should&lt;T&gt;(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))) | Begins a fluent assertion on the specified enumerable. |
| [Should&lt;TKey, TValue&gt;(IReadOnlyDictionary&lt;TKey, TValue&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))) | Begins a fluent assertion on the specified read-only dictionary. |
| [Should&lt;TKey, TValue&gt;(Dictionary&lt;TKey, TValue&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))) | Begins a fluent assertion on the specified dictionary. |
| [Should&lt;T&gt;(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))) | Begins a fluent assertion on the specified read-only span. |
| [Should(Action)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should(system-action)) | Begins a fluent assertion on the specified action. |

## Should&lt;T&gt;(T) {id="mrkwatkins-assertions-shouldextensions-should-1(-0)"}

Begins a fluent assertion on the specified value.

```c#
public static ObjectAssertions<T> Should<T>(this T? value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(-0)"}

| Name | Description |
| ---- | ----------- |
| T | The type of the value. |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T | The value to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(-0)"}

[ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md)

An [ObjectAssertions&lt;T&gt;](MrKWatkins.Assertions.ObjectAssertions-1.md) for the value.
## Should(String) {id="mrkwatkins-assertions-shouldextensions-should(system-string)"}

Begins a fluent assertion on the specified string value.

```c#
public static StringAssertions Should(this string? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-string)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The string value to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-string)"}

[StringAssertions](MrKWatkins.Assertions.StringAssertions.md)

A [StringAssertions](MrKWatkins.Assertions.StringAssertions.md) for the value.
## Should(Exception) {id="mrkwatkins-assertions-shouldextensions-should(system-exception)"}

Begins a fluent assertion on the specified exception.

```c#
public static ExceptionAssertions<Exception> Should(this Exception? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-exception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Exception](https://learn.microsoft.com/en-gb/dotnet/api/System.Exception) | The exception to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-exception)"}

[ExceptionAssertions&lt;Exception&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md)

An [ExceptionAssertions&lt;T&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md) for the exception.
## Should(ArgumentException) {id="mrkwatkins-assertions-shouldextensions-should(system-argumentexception)"}

Begins a fluent assertion on the specified [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException).

```c#
public static ExceptionAssertions<ArgumentException> Should(this ArgumentException? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-argumentexception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ArgumentException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentException) | The exception to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-argumentexception)"}

[ExceptionAssertions&lt;ArgumentException&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md)

An [ExceptionAssertions&lt;T&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md) for the exception.
## Should(ArgumentOutOfRangeException) {id="mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)"}

Begins a fluent assertion on the specified [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException).

```c#
public static ExceptionAssertions<ArgumentOutOfRangeException> Should(this ArgumentOutOfRangeException? value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ArgumentOutOfRangeException](https://learn.microsoft.com/en-gb/dotnet/api/System.ArgumentOutOfRangeException) | The exception to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-argumentoutofrangeexception)"}

[ExceptionAssertions&lt;ArgumentOutOfRangeException&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md)

An [ExceptionAssertions&lt;T&gt;](MrKWatkins.Assertions.ExceptionAssertions-1.md) for the exception.
## Should&lt;T&gt;(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

Begins a fluent assertion on the specified enumerable.

```c#
public static EnumerableAssertions<IEnumerable<T>, T> Should<T>(this IEnumerable<T>? value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

| Name | Description |
| ---- | ----------- |
| T | The type of elements in the enumerable. |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) | The enumerable to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

[EnumerableAssertions&lt;IEnumerable&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)

An [EnumerableAssertions&lt;TEnumerable, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md) for the enumerable.
## Should&lt;TKey, TValue&gt;(IReadOnlyDictionary&lt;TKey, TValue&gt;) {id="mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

Begins a fluent assertion on the specified read-only dictionary.

```c#
public static ReadOnlyDictionaryAssertions<IReadOnlyDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

| Name | Description |
| ---- | ----------- |
| TKey | The type of the dictionary keys. |
| TValue | The type of the dictionary values. |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IReadOnlyDictionary&lt;TKey, TValue&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2) | The dictionary to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))"}

[ReadOnlyDictionaryAssertions&lt;IReadOnlyDictionary&lt;TKey, TValue&gt;, TKey, TValue&gt;](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.md)

A [ReadOnlyDictionaryAssertions&lt;TDictionary, TKey, TValue&gt;](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.md) for the dictionary.
## Should&lt;TKey, TValue&gt;(Dictionary&lt;TKey, TValue&gt;) {id="mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

Begins a fluent assertion on the specified dictionary.

```c#
public static ReadOnlyDictionaryAssertions<Dictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>(this Dictionary<TKey, TValue> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

| Name | Description |
| ---- | ----------- |
| TKey | The type of the dictionary keys. |
| TValue | The type of the dictionary values. |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Dictionary&lt;TKey, TValue&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.Dictionary-2) | The dictionary to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))"}

[ReadOnlyDictionaryAssertions&lt;Dictionary&lt;TKey, TValue&gt;, TKey, TValue&gt;](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.md)

A [ReadOnlyDictionaryAssertions&lt;TDictionary, TKey, TValue&gt;](MrKWatkins.Assertions.ReadOnlyDictionaryAssertions-3.md) for the dictionary.
## Should&lt;T&gt;(ReadOnlySpan&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

Begins a fluent assertion on the specified read-only span.

```c#
public static ReadOnlySpanAssertions<T> Should<T>(this ReadOnlySpan<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

| Name | Description |
| ---- | ----------- |
| T | The type of elements in the span. |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ReadOnlySpan&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) | The span to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-readonlyspan((-0)))"}

[ReadOnlySpanAssertions&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.md)

A [ReadOnlySpanAssertions&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.md) for the span.
## Should(Action) {id="mrkwatkins-assertions-shouldextensions-should(system-action)"}

Begins a fluent assertion on the specified action.

```c#
public static ActionAssertions Should(this Action value);
```

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should(system-action)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Action](https://learn.microsoft.com/en-gb/dotnet/api/System.Action) | The action to assert on. |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should(system-action)"}

[ActionAssertions](MrKWatkins.Assertions.ActionAssertions.md)

An [ActionAssertions](MrKWatkins.Assertions.ActionAssertions.md) for the action.
