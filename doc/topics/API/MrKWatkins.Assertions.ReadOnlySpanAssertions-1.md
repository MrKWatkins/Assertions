# ReadOnlySpanAssertions&lt;T&gt; Struct
## Definition

Provides assertions for read-only span values with zero-allocation support.

```c#
public sealed struct ReadOnlySpanAssertions<T>
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The type of elements in the span. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [ReadOnlySpanAssertions(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.-ctor.md) | Provides assertions for read-only span values with zero-allocation support. |

## Properties

| Name | Description |
| ---- | ----------- |
| [Value](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.Value.md) | Gets the span value being asserted on. |

## Methods

| Name | Description |
| ---- | ----------- |
| [BeEmpty()](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.BeEmpty.md) | Asserts that the span is empty. |
| [NotBeEmpty()](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.NotBeEmpty.md) | Asserts that the span is not empty. |
| [NotSequenceEqual(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.NotSequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-readonlyspan((-0)))) | Asserts that the span is not sequence equal to the expected elements. |
| [NotSequenceEqual(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.NotSequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-notsequenceequal(system-collections-generic-ienumerable((-0)))) | Asserts that the span is not sequence equal to the expected enumerable elements. |
| [SequenceEqual(ReadOnlySpan&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.SequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-readonlyspan((-0)))) | Asserts that the span is sequence equal to the expected elements. |
| [SequenceEqual(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.ReadOnlySpanAssertions-1.SequenceEqual.md#mrkwatkins-assertions-readonlyspanassertions-1-sequenceequal(system-collections-generic-ienumerable((-0)))) | Asserts that the span is sequence equal to the expected enumerable elements. |

