# Dates and Times

Assertions are available for [`TimeSpan`](https://learn.microsoft.com/en-us/dotnet/api/system.timespan), [`DateTimeOffset`](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset) and
[`DateOnly`](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly) via `.Should()`. All of them support the comparisons from
[`ComparableAssertions<TSelf, T>`](api/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/index.md) and equality from
[`ObjectAssertions<TSelf, T>`](api/MrKWatkins.Assertions/ObjectAssertions-TSelf-T/index.md):

```csharp
var value = TimeSpan.FromSeconds(5);
value.Should().Equal(TimeSpan.FromMilliseconds(5000));
value.Should().NotEqual(TimeSpan.FromSeconds(10));
value.Should().BeLessThan(TimeSpan.FromSeconds(10));
value.Should().BeLessThanOrEqualTo(TimeSpan.FromSeconds(5));
value.Should().BeGreaterThan(TimeSpan.FromSeconds(1));
value.Should().BeGreaterThanOrEqualTo(TimeSpan.FromSeconds(5));
value.Should().BeInRange(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10)); // Inclusive.
```

Chainable methods return an [`AssertionsChain<TAssertions, T>`](api/MrKWatkins.Assertions/AssertionsChain-TAssertions-T/index.md).

Values are shown in assertion messages in a culture-invariant format: `TimeSpan` uses the [constant format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-timespan-format-strings#the-constant-c-format-specifier),
for example `01:30:00`, `DateTimeOffset` uses ISO 8601, for example `2026-09-30T12:00:00+01:00`, and `DateOnly` uses `yyyy-MM-dd`, for example `2026-09-30`.

## TimeSpan

[`TimeSpanAssertions`](api/MrKWatkins.Assertions/TimeSpanAssertions/index.md) extends [`NumericAssertions<TSelf, T>`](api/MrKWatkins.Assertions/NumericAssertions-TSelf-T/index.md), so it has the sign and
zero assertions too. As with numbers, [`TimeSpan.Zero`](https://learn.microsoft.com/en-us/dotnet/api/system.timespan.zero) is neither positive nor negative:

```csharp
TimeSpan.FromSeconds(5).Should().BePositive();
TimeSpan.FromSeconds(-5).Should().BeNegative();
TimeSpan.Zero.Should().BeZero();
TimeSpan.FromSeconds(1).Should().NotBeZero();
```

When asserting on measured durations, such as elapsed times from a [`Stopwatch`](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch), use
[`BeApproximately`](api/MrKWatkins.Assertions/TimeSpanAssertions/BeApproximately.md) with a precision that defines the allowed tolerance either side of the expected value:

```csharp
var elapsed = stopwatch.Elapsed;
elapsed.Should().BeApproximately(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100));
elapsed.Should().NotBeApproximately(TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
```

## DateTimeOffset

[`DateTimeOffsetAssertions`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/index.md) adds [`BeBefore`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/BeBefore.md),
[`BeOnOrBefore`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/BeOnOrBefore.md), [`BeAfter`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/BeAfter.md) and
[`BeOnOrAfter`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/BeOnOrAfter.md), which read more naturally than the comparison methods:

```csharp
var value = new DateTimeOffset(2026, 9, 30, 12, 0, 0, TimeSpan.Zero);
value.Should().BeAfter(value.AddDays(-1));
value.Should().BeOnOrBefore(value);
```

Use [`BeApproximately`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/BeApproximately.md) to check a value is close to an expected value, for example a timestamp that should be about now:

```csharp
order.CreatedAt.Should().BeApproximately(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(5));
```

Like [`DateTimeOffset.Equals`](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.equals), equality and comparisons are based on the point in time and ignore the offset,
so 12:00 +00:00 equals 13:00 +01:00. Use [`BeExactly`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/BeExactly.md) to compare the offset too, or
[`HaveOffset`](api/MrKWatkins.Assertions/DateTimeOffsetAssertions/HaveOffset.md) to check just the offset:

```csharp
var utc = new DateTimeOffset(2026, 9, 30, 12, 0, 0, TimeSpan.Zero);
var plusOne = new DateTimeOffset(2026, 9, 30, 13, 0, 0, TimeSpan.FromHours(1));

utc.Should().Equal(plusOne);        // Passes - same point in time.
utc.Should().BeExactly(plusOne);    // Fails - different offsets.
plusOne.Should().HaveOffset(TimeSpan.FromHours(1));
```

## DateOnly

[`DateOnlyAssertions`](api/MrKWatkins.Assertions/DateOnlyAssertions/index.md) has the same [`BeBefore`](api/MrKWatkins.Assertions/DateOnlyAssertions/BeBefore.md),
[`BeOnOrBefore`](api/MrKWatkins.Assertions/DateOnlyAssertions/BeOnOrBefore.md), [`BeAfter`](api/MrKWatkins.Assertions/DateOnlyAssertions/BeAfter.md) and
[`BeOnOrAfter`](api/MrKWatkins.Assertions/DateOnlyAssertions/BeOnOrAfter.md) assertions, plus [`BeOnDayOfWeek`](api/MrKWatkins.Assertions/DateOnlyAssertions/BeOnDayOfWeek.md):

```csharp
var date = new DateOnly(2026, 9, 30);
date.Should().BeAfter(new DateOnly(2026, 1, 1)).And.BeOnDayOfWeek(DayOfWeek.Wednesday);
```
