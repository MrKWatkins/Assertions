# Time Spans

[`TimeSpanAssertions`](API/MrKWatkins.Assertions/TimeSpanAssertions/index.md) is available for [`TimeSpan`](https://learn.microsoft.com/en-us/dotnet/api/system.timespan) via `.Should()`.

## Equality

Equality uses the base [`Equal`](API/MrKWatkins.Assertions/ObjectAssertions-T/Equal.md) and [`NotEqual`](API/MrKWatkins.Assertions/ObjectAssertions-T/NotEqual.md) from [`ObjectAssertions<T>`](API/MrKWatkins.Assertions/ObjectAssertions-T/index.md):

```csharp
var value = TimeSpan.FromSeconds(5);
value.Should().Equal(TimeSpan.FromMilliseconds(5000));
value.Should().NotEqual(TimeSpan.FromSeconds(10));
```

## Sign and Zero

```csharp
TimeSpan.FromSeconds(5).Should().BePositive();
TimeSpan.FromSeconds(-5).Should().BeNegative();
TimeSpan.Zero.Should().BeZero();
TimeSpan.FromSeconds(1).Should().NotBeZero();
```

## Comparisons

```csharp
var value = TimeSpan.FromSeconds(5);
value.Should().BeLessThan(TimeSpan.FromSeconds(10));
value.Should().BeLessThanOrEqualTo(TimeSpan.FromSeconds(5));
value.Should().BeGreaterThan(TimeSpan.FromSeconds(1));
value.Should().BeGreaterThanOrEqualTo(TimeSpan.FromSeconds(5));
```

[`BeInRange`](API/MrKWatkins.Assertions/TimeSpanAssertions/BeInRange.md) checks the value is between a minimum and maximum, inclusive:

```csharp
TimeSpan.FromSeconds(5).Should().BeInRange(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10));
```

## Approximate Equality

When asserting on measured durations, such as elapsed times from a [`Stopwatch`](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch), use [`BeApproximately`](API/MrKWatkins.Assertions/TimeSpanAssertions/BeApproximately.md) with a precision that defines the allowed tolerance either side of the expected value:

```csharp
var elapsed = stopwatch.Elapsed;
elapsed.Should().BeApproximately(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100));
elapsed.Should().NotBeApproximately(TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
```

Chainable methods return a [`TimeSpanAssertionsChain`](API/MrKWatkins.Assertions/TimeSpanAssertionsChain/index.md).
