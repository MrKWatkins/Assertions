# ShouldExtensions.Should Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Should&lt;T&gt;(T)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(-0)) |  |
| [Should&lt;T&gt;(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))) |  |
| [Should&lt;T&gt;(IReadOnlyCollection&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlycollection((-0)))) |  |
| [Should&lt;T&gt;(ICollection&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-icollection((-0)))) |  |
| [Should&lt;T&gt;(IReadOnlyList&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlylist((-0)))) |  |
| [Should&lt;T&gt;(IList&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ilist((-0)))) |  |
| [Should&lt;T&gt;(List&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-list((-0)))) |  |
| [Should&lt;T&gt;(IReadOnlySet&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlyset((-0)))) |  |
| [Should&lt;T&gt;(ISet&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-iset((-0)))) |  |
| [Should&lt;T&gt;(HashSet&lt;T&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-hashset((-0)))) |  |
| [Should&lt;TKey, TValue&gt;(IReadOnlyDictionary&lt;TKey, TValue&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-ireadonlydictionary((-0-1)))) |  |
| [Should&lt;TKey, TValue&gt;(Dictionary&lt;TKey, TValue&gt;)](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-2(system-collections-generic-dictionary((-0-1)))) |  |
| [Should&lt;T&gt;(T\[\])](MrKWatkins.Assertions.ShouldExtensions.Should.md#mrkwatkins-assertions-shouldextensions-should-1(-0())) |  |
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
## Should&lt;T&gt;(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ienumerable((-0)))"}

```c#
public static EnumerableAssertions<IEnumerable<T>, T> Should<T>(this IEnumerable<T> value);
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
## Should&lt;T&gt;(IReadOnlyCollection&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlycollection((-0)))"}

```c#
public static EnumerableAssertions<IReadOnlyCollection<T>, T> Should<T>(this IReadOnlyCollection<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlycollection((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlycollection((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IReadOnlyCollection&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlycollection((-0)))"}

[EnumerableAssertions&lt;IReadOnlyCollection&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
## Should&lt;T&gt;(ICollection&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-icollection((-0)))"}

```c#
public static EnumerableAssertions<ICollection<T>, T> Should<T>(this ICollection<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-icollection((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-icollection((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ICollection&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.ICollection-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-icollection((-0)))"}

[EnumerableAssertions&lt;ICollection&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
## Should&lt;T&gt;(IReadOnlyList&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlylist((-0)))"}

```c#
public static ReadOnlyListAssertions<IReadOnlyList<T>, T> Should<T>(this IReadOnlyList<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlylist((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlylist((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IReadOnlyList&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyList-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlylist((-0)))"}

[ReadOnlyListAssertions&lt;IReadOnlyList&lt;T&gt;, T&gt;](MrKWatkins.Assertions.ReadOnlyListAssertions-2.md)
## Should&lt;T&gt;(IList&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ilist((-0)))"}

```c#
public static EnumerableAssertions<IList<T>, T> Should<T>(this IList<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ilist((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ilist((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IList&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IList-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ilist((-0)))"}

[EnumerableAssertions&lt;IList&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
## Should&lt;T&gt;(List&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-list((-0)))"}

```c#
public static ReadOnlyListAssertions<List<T>, T> Should<T>(this List<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-list((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-list((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [List&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.List-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-list((-0)))"}

[ReadOnlyListAssertions&lt;List&lt;T&gt;, T&gt;](MrKWatkins.Assertions.ReadOnlyListAssertions-2.md)
## Should&lt;T&gt;(IReadOnlySet&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlyset((-0)))"}

```c#
public static EnumerableAssertions<IReadOnlySet<T>, T> Should<T>(this IReadOnlySet<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlyset((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlyset((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IReadOnlySet&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlySet-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-ireadonlyset((-0)))"}

[EnumerableAssertions&lt;IReadOnlySet&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
## Should&lt;T&gt;(ISet&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-iset((-0)))"}

```c#
public static EnumerableAssertions<ISet<T>, T> Should<T>(this ISet<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-iset((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-iset((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [ISet&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.ISet-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-iset((-0)))"}

[EnumerableAssertions&lt;ISet&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
## Should&lt;T&gt;(HashSet&lt;T&gt;) {id="mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-hashset((-0)))"}

```c#
public static EnumerableAssertions<HashSet<T>, T> Should<T>(this HashSet<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-hashset((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-hashset((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [HashSet&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.HashSet-1) |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(system-collections-generic-hashset((-0)))"}

[EnumerableAssertions&lt;HashSet&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
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
## Should&lt;T&gt;(T\[\]) {id="mrkwatkins-assertions-shouldextensions-should-1(-0())"}

```c#
public static EnumerableAssertions<T[], T> Should<T>(this T[] value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-shouldextensions-should-1(-0())"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-shouldextensions-should-1(-0())"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T\[\] |  |

## Returns {id="returns-mrkwatkins-assertions-shouldextensions-should-1(-0())"}

[EnumerableAssertions&lt;T\[\], T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md)
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
