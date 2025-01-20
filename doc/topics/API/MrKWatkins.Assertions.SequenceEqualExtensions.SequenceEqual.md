# SequenceEqualExtensions.SequenceEqual Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [SequenceEqual&lt;T&gt;(ReadOnlySpanAssertions&lt;T&gt;, ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.SequenceEqualExtensions.SequenceEqual.md#mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-readonlyspan((-0)))) |  |
| [SequenceEqual&lt;T&gt;(ReadOnlySpanAssertions&lt;T&gt;, IReadOnlyList&lt;T&gt;)](MrKWatkins.Assertions.SequenceEqualExtensions.SequenceEqual.md#mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-collections-generic-ireadonlylist((-0)))) |  |
| [SequenceEqual&lt;TList, T&gt;(ReadOnlyListAssertions&lt;TList, T&gt;, IReadOnlyList&lt;T&gt;)](MrKWatkins.Assertions.SequenceEqualExtensions.SequenceEqual.md#mrkwatkins-assertions-sequenceequalextensions-sequenceequal-2(mrkwatkins-assertions-readonlylistassertions((-0-1))-system-collections-generic-ireadonlylist((-1)))) |  |
| [SequenceEqual&lt;T&gt;(EnumerableAssertions&lt;IEnumerable&lt;T&gt;, T&gt;, IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.SequenceEqualExtensions.SequenceEqual.md#mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-enumerableassertions((system-collections-generic-ienumerable((-0))-0))-system-collections-generic-ienumerable((-0)))) |  |

## SequenceEqual&lt;T&gt;(ReadOnlySpanAssertions&lt;T&gt;, ReadOnlySpan&lt;T&gt;) {id="mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-readonlyspan((-0)))"}

```c#
public static ReadOnlySpanAssertionsChain<T> SequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, params ReadOnlySpan<T> expected);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-readonlyspan((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-readonlyspan((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ReadOnlySpanAssertions&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.md) |  |
| expected | [ReadOnlySpan&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) |  |

## Returns {id="returns-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-readonlyspan((-0)))"}

[ReadOnlySpanAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md)
## SequenceEqual&lt;T&gt;(ReadOnlySpanAssertions&lt;T&gt;, IReadOnlyList&lt;T&gt;) {id="mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-collections-generic-ireadonlylist((-0)))"}

```c#
public static ReadOnlySpanAssertionsChain<T> SequenceEqual<T>(this ReadOnlySpanAssertions<T> assertions, params IReadOnlyList<T> expected);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-collections-generic-ireadonlylist((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-collections-generic-ireadonlylist((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ReadOnlySpanAssertions&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.md) |  |
| expected | [IReadOnlyList&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyList-1) |  |

## Returns {id="returns-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-readonlyspanassertions((-0))-system-collections-generic-ireadonlylist((-0)))"}

[ReadOnlySpanAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md)
## SequenceEqual&lt;TList, T&gt;(ReadOnlyListAssertions&lt;TList, T&gt;, IReadOnlyList&lt;T&gt;) {id="mrkwatkins-assertions-sequenceequalextensions-sequenceequal-2(mrkwatkins-assertions-readonlylistassertions((-0-1))-system-collections-generic-ireadonlylist((-1)))"}

```c#
public static ReadOnlyListAssertionsChain<TList, T> SequenceEqual<TList, T>(this ReadOnlyListAssertions<TList, T> assertions, params IReadOnlyList<T> expected)
   where TList : IReadOnlyList<T>;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-2(mrkwatkins-assertions-readonlylistassertions((-0-1))-system-collections-generic-ireadonlylist((-1)))"}

| Name | Description |
| ---- | ----------- |
| TList |  |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-2(mrkwatkins-assertions-readonlylistassertions((-0-1))-system-collections-generic-ireadonlylist((-1)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [ReadOnlyListAssertions&lt;TList, T&gt;](MrKWatkins.Assertions.ReadOnlyListAssertions-2.md) |  |
| expected | [IReadOnlyList&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyList-1) |  |

## Returns {id="returns-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-2(mrkwatkins-assertions-readonlylistassertions((-0-1))-system-collections-generic-ireadonlylist((-1)))"}

[ReadOnlyListAssertionsChain&lt;TList, T&gt;](MrKWatkins.Assertions.ReadOnlyListAssertionsChain-2.md)
## SequenceEqual&lt;T&gt;(EnumerableAssertions&lt;IEnumerable&lt;T&gt;, T&gt;, IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-enumerableassertions((system-collections-generic-ienumerable((-0))-0))-system-collections-generic-ienumerable((-0)))"}

```c#
public static EnumerableAssertionsChain<IEnumerable<T>, T> SequenceEqual<T>(this EnumerableAssertions<IEnumerable<T>, T> assertions, params IEnumerable<T> expected);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-enumerableassertions((system-collections-generic-ienumerable((-0))-0))-system-collections-generic-ienumerable((-0)))"}

| Name | Description |
| ---- | ----------- |
| T |  |

## Parameters {id="parameters-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-enumerableassertions((system-collections-generic-ienumerable((-0))-0))-system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertions | [EnumerableAssertions&lt;IEnumerable&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertions-2.md) |  |
| expected | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) |  |

## Returns {id="returns-mrkwatkins-assertions-sequenceequalextensions-sequenceequal-1(mrkwatkins-assertions-enumerableassertions((system-collections-generic-ienumerable((-0))-0))-system-collections-generic-ienumerable((-0)))"}

[EnumerableAssertionsChain&lt;IEnumerable&lt;T&gt;, T&gt;](MrKWatkins.Assertions.EnumerableAssertionsChain-2.md)
