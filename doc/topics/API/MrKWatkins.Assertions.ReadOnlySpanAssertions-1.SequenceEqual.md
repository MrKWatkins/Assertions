# ReadOnlySpanAssertions&lt;T&gt;.SequenceEqual Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [SequenceEqual(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.SequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-readonlyspan((-0)))) | Asserts that the span is sequence equal to the expected elements. |
| [SequenceEqual(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.SequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-collections-generic-ienumerable((-0)))) | Asserts that the span is sequence equal to the expected enumerable elements. |

## SequenceEqual(ReadOnlySpan&lt;T&gt;) {id="mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-readonlyspan((-0)))"}

Asserts that the span is sequence equal to the expected elements.

```c#
public ReadOnlySpanAssertionsChain<T> SequenceEqual(params ReadOnlySpan<T> expected);
```

## Parameters {id="parameters-mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-readonlyspan((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [ReadOnlySpan&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) | The expected elements. |

## Returns {id="returns-mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-readonlyspan((-0)))"}

[ReadOnlySpanAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md)

A [ReadOnlySpanAssertionsChain&lt;TItem&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md) for chaining further assertions.
## SequenceEqual(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-collections-generic-ienumerable((-0)))"}

Asserts that the span is sequence equal to the expected enumerable elements.

```c#
public ReadOnlySpanAssertionsChain<T> SequenceEqual(IEnumerable<T> expected);
```

## Parameters {id="parameters-mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) | The expected elements. |

## Returns {id="returns-mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-collections-generic-ienumerable((-0)))"}

[ReadOnlySpanAssertionsChain&lt;T&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md)

A [ReadOnlySpanAssertionsChain&lt;TItem&gt;](MrKWatkins.Assertions.ReadOnlySpanAssertionsChain-1.md) for chaining further assertions.
