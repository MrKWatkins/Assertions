# ReadOnlySpanAssertions&lt;T&gt;.NotSequenceEqual Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [NotSequenceEqual(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.NotSequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-readonlyspan((-0)))) | Asserts that the span is not sequence equal to the expected elements. |
| [NotSequenceEqual(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.NotSequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-collections-generic-ienumerable((-0)))) | Asserts that the span is not sequence equal to the expected enumerable elements. |

## NotSequenceEqual(ReadOnlySpan&lt;T&gt;) {id="mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-readonlyspan((-0)))"}

Asserts that the span is not sequence equal to the expected elements.

```c#
public ReadOnlySpanAssertionsChain<T> NotSequenceEqual(params ReadOnlySpan<T> expected);
```

## Parameters {id="parameters-mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-readonlyspan((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [ReadOnlySpan&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) | The elements the span should not be sequence equal to. |

## Returns {id="returns-mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-readonlyspan((-0)))"}

[ReadOnlySpanAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md)

A [ReadOnlySpanAssertionsChain&lt;TItem&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md) for chaining further assertions.
## NotSequenceEqual(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-collections-generic-ienumerable((-0)))"}

Asserts that the span is not sequence equal to the expected enumerable elements.

```c#
public ReadOnlySpanAssertionsChain<T> NotSequenceEqual(IEnumerable<T> expected);
```

## Parameters {id="parameters-mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) | The elements the span should not be sequence equal to. |

## Returns {id="returns-mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-collections-generic-ienumerable((-0)))"}

[ReadOnlySpanAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md)

A [ReadOnlySpanAssertionsChain&lt;TItem&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md) for chaining further assertions.
