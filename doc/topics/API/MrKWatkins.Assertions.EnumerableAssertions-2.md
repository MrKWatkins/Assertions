# EnumerableAssertions&lt;TEnumerable, T&gt; Class
## Definition

Provides assertions for enumerable values.

```c#
public class EnumerableAssertions<TEnumerable, T> : ObjectAssertions<TEnumerable>
   where TEnumerable : IEnumerable<T>
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TEnumerable | The type of the enumerable being asserted on. |
| T | The type of elements in the enumerable. |

## Constructors

| Name | Description |
| ---- | ----------- |
| [EnumerableAssertions(TEnumerable)](MrKWatkins.Assertions.EnumerableAssertions-2.-ctor.md) | Provides assertions for enumerable values. |

## Methods

| Name | Description |
| ---- | ----------- |
| [ContainSingle(Func&lt;T, Boolean&gt;, String)](MrKWatkins.Assertions.EnumerableAssertions-2.ContainSingle.md) | Asserts that the enumerable contains exactly one item that satisfies the specified predicate. |
| [NotSequenceEqual(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.EnumerableAssertions-2.NotSequenceEqual.md) | Asserts that the enumerable is not sequence equal to the expected elements. |
| [OnlyContain(Func&lt;T, Boolean&gt;, String)](MrKWatkins.Assertions.EnumerableAssertions-2.OnlyContain.md) | Asserts that all items in the enumerable satisfy the specified predicate. |
| [SequenceEqual(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.EnumerableAssertions-2.SequenceEqual.md) | Asserts that the enumerable is sequence equal to the expected elements. |

