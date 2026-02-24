# Collections

[`EnumerableAssertions<TEnumerable, T>`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/index.md) is available for any [`IEnumerable<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) via `.Should()`.

## Sequence Equality

By default, ordering is **strict** — elements must appear in the same order.

```csharp
var numbers = new[] { 1, 2, 3 };

numbers.Should().SequenceEqual(1, 2, 3);   // passes
numbers.Should().SequenceEqual(3, 2, 1);   // fails — wrong order
numbers.Should().NotSequenceEqual(4, 5, 6);
```

Pass a collection as the expected value, or use a custom [`IEqualityComparer<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1) or predicate:

```csharp
IEnumerable<string> actual = new[] { "a", "b", "c" };
IEnumerable<string> expected = new[] { "A", "B", "C" };

actual.Should().SequenceEqual(expected, StringComparer.OrdinalIgnoreCase);

actual.Should().SequenceEqual(expected,
    (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
```

See [`SequenceEqual`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/SequenceEqual.md) and [`NotSequenceEqual`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/NotSequenceEqual.md).

## Contains

```csharp
var numbers = new[] { 1, 2, 3 };

numbers.Should().Contain(2);
numbers.Should().NotContain(5);
```

With a custom comparer or predicate:

```csharp
IEnumerable<string> items = new[] { "Hello", "World" };

items.Should().Contain("hello", StringComparer.OrdinalIgnoreCase);
items.Should().Contain("hello", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
```

See [`Contain`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/Contain.md) and [`NotContain`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/NotContain.md).

## Single Item

Assert that the collection contains exactly one element using [`ContainSingle`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/ContainSingle.md):

```csharp
var single = new[] { 42 };
single.Should().ContainSingle().And.Equal(42);
```

Or exactly one element matching a predicate:

```csharp
var numbers = new[] { 1, 2, 3 };
numbers.Should().ContainSingle(x => x > 2).And.Equal(3);
```

## All Items Satisfy a Predicate

```csharp
var numbers = new[] { 2, 4, 6 };
numbers.Should().OnlyContain(x => x % 2 == 0);
```

The error message includes the predicate expression text and the first failing item's index. See [`OnlyContain`](API/MrKWatkins.Assertions/EnumerableAssertions-TEnumerable-T/OnlyContain.md).

## Count

These methods from [`CountExtensions`](API/MrKWatkins.Assertions/CountExtensions/index.md) work on any [`IEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable) (not just generic), and use [`ICollection.Count`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.icollection.count) when available for efficiency:

```csharp
IEnumerable<int> items = new[] { 1, 2, 3 };

items.Should().HaveCount(3);
items.Should().NotHaveCount(5);
```

```csharp
items.Should().BeEmpty();         // fails — has 3 elements
new int[0].Should().BeEmpty();    // passes
items.Should().NotBeEmpty();      // passes
```

## Non-Generic Enumerables

For legacy non-generic [`IEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable) types, use the extension methods from [`EnumerableExtensions`](API/MrKWatkins.Assertions/EnumerableExtensions/index.md):

```csharp
System.Collections.IEnumerable legacy = new ArrayList { 1, 2, 3 };

legacy.Should().SequenceEqual(1, 2, 3);
legacy.Should().NotSequenceEqual(4, 5, 6);
```

## Chaining

Chainable methods return an [`EnumerableAssertionsChain<TEnumerable, T>`](API/MrKWatkins.Assertions/EnumerableAssertionsChain-TEnumerable-T/index.md):

```csharp
new[] { 1, 2, 3 }
    .Should()
    .NotBeNull()
    .And.HaveCount(3)
    .And.Contain(2);
```
