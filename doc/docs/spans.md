# Spans

[`ReadOnlySpanAssertions<T>`](API/MrKWatkins.Assertions/ReadOnlySpanAssertions-T/index.md) is a [`ref struct`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct) that provides zero-allocation assertions for [`Span<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) and [`ReadOnlySpan<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1).

Call `.Should()` on a span to get a [`ReadOnlySpanAssertions<T>`](API/MrKWatkins.Assertions/ReadOnlySpanAssertions-T/index.md):

```csharp
Span<int> span = [1, 2, 3];
span.Should().SequenceEqual(1, 2, 3);

ReadOnlySpan<char> chars = "hello".AsSpan();
chars.Should().NotBeEmpty();
```

> **Note:** Because `ReadOnlySpanAssertions<T>` is a `ref struct`, it cannot be stored in a field or captured in a lambda. Create the span and call `.Should()` within the same stack frame.

## Empty

```csharp
Span<int> empty = [];
empty.Should().BeEmpty();

Span<int> nonEmpty = [1, 2, 3];
nonEmpty.Should().NotBeEmpty();
```

## Sequence Equality

Ordering is **strict** by default.

```csharp
Span<int> span = [1, 2, 3];
span.Should().SequenceEqual(1, 2, 3);   // passes
span.Should().SequenceEqual(3, 2, 1);   // fails — wrong order
span.Should().NotSequenceEqual(4, 5, 6);
```

With a custom [`IEqualityComparer<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1):

```csharp
Span<string> span = ["hello", "world"];
span.Should().SequenceEqual(["HELLO", "WORLD"], StringComparer.OrdinalIgnoreCase);
```

With a predicate:

```csharp
span.Should().SequenceEqual(["HELLO", "WORLD"],
    (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
```

See [`SequenceEqual`](API/MrKWatkins.Assertions/ReadOnlySpanAssertions-T/SequenceEqual.md) and [`NotSequenceEqual`](API/MrKWatkins.Assertions/ReadOnlySpanAssertions-T/NotSequenceEqual.md).

### Comparing Against an Enumerable

Spans can also be compared against an [`IEnumerable<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1):

```csharp
Span<int> span = [1, 2, 3];
IEnumerable<int> expected = Enumerable.Range(1, 3);

span.Should().SequenceEqual(expected);
span.Should().SequenceEqual(expected, EqualityComparer<int>.Default);
```

## Chaining

Chainable methods return a [`ReadOnlySpanAssertionsChain<T>`](API/MrKWatkins.Assertions/ReadOnlySpanAssertionsChain-TItem/index.md):

```csharp
Span<int> span = [1, 2, 3];
span.Should().NotBeEmpty().And.SequenceEqual(1, 2, 3);
```
