# Sets

[`ReadOnlySetAssertions<TSet, T>`](api/MrKWatkins.Assertions/ReadOnlySetAssertions-TSet-T/index.md) is available for [`IReadOnlySet<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlyset-1) and [`HashSet<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1) via `.Should()`. It extends [`EnumerableAssertions<TSelf, TEnumerable, T>`](api/MrKWatkins.Assertions/EnumerableAssertions-TSelf-TEnumerable-T/index.md), so all enumerable assertions are available too.

## Set Comparison

Comparisons use set semantics — order and duplicates are ignored, and membership is judged by the set's own comparer:

```csharp
var set = new HashSet<int> { 1, 2, 3 };

set.Should().SetEquals(3, 2, 1);
set.Should().IsSupersetOf(1, 2);
set.Should().IsSubsetOf(1, 2, 3, 4);
```

See [`SetEquals`](api/MrKWatkins.Assertions/ReadOnlySetAssertions-TSet-T/SetEquals.md), [`IsSupersetOf`](api/MrKWatkins.Assertions/ReadOnlySetAssertions-TSet-T/IsSupersetOf.md) and [`IsSubsetOf`](api/MrKWatkins.Assertions/ReadOnlySetAssertions-TSet-T/IsSubsetOf.md).

## Chaining

Chainable methods return an [`AssertionsChain<TAssertions, T>`](api/MrKWatkins.Assertions/AssertionsChain-TAssertions-T/index.md):

```csharp
set.Should()
    .IsSupersetOf(1, 2)
    .And.IsSubsetOf(1, 2, 3, 4);
```

All object-level assertions are also available:

```csharp
HashSet<int>? maybeNull = GetSet();
maybeNull.Should().NotBeNull().And.SetEquals(1, 2, 3);
```
