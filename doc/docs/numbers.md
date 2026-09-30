# Numbers

Integers, `decimal` and floating-point values share their comparison, sign and zero assertions, which are defined on
[`ComparableAssertions<TSelf, T>`](API/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/index.md) and
[`NumericAssertions<TSelf, T>`](API/MrKWatkins.Assertions/NumericAssertions-TSelf-T/index.md). Chainable methods return an
[`AssertionsChain<TAssertions, T>`](API/MrKWatkins.Assertions/AssertionsChain-TAssertions-T/index.md) whose `.And` is the assertions for the specific numeric type.

## Comparisons

```csharp
5.Should().BeLessThan(10);
5.Should().BeLessThanOrEqualTo(5);
10.Should().BeGreaterThan(5);
10.Should().BeGreaterThanOrEqualTo(10);
5.Should().BeInRange(1, 10); // Inclusive.
```

See [`BeLessThan`](API/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/BeLessThan.md), [`BeLessThanOrEqualTo`](API/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/BeLessThanOrEqualTo.md),
[`BeGreaterThan`](API/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/BeGreaterThan.md), [`BeGreaterThanOrEqualTo`](API/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/BeGreaterThanOrEqualTo.md)
and [`BeInRange`](API/MrKWatkins.Assertions/ComparableAssertions-TSelf-T/BeInRange.md).

## Sign and Zero

```csharp
42.Should().BePositive();
42.Should().NotBeNegative();
(-5).Should().BeNegative();
(-5).Should().NotBePositive();
0.Should().BeZero();
1.Should().NotBeZero();
```

Zero is neither positive nor negative, so `0.Should().BePositive()` fails and `0.Should().NotBePositive()` passes. See
[`BeZero`](API/MrKWatkins.Assertions/NumericAssertions-TSelf-T/BeZero.md), [`BePositive`](API/MrKWatkins.Assertions/NumericAssertions-TSelf-T/BePositive.md),
[`BeNegative`](API/MrKWatkins.Assertions/NumericAssertions-TSelf-T/BeNegative.md) and their `Not` counterparts.

## Integers

[`IntegerAssertions<T>`](API/MrKWatkins.Assertions/IntegerAssertions-T/index.md) is available for all integer types (`byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `nint`, `nuint`) via `.Should()`.

```csharp
int value = 42;
value.Should().Equal(42);
value.Should().NotEqual(0);
```

Integer equality supports cross-type comparisons via [`IBinaryInteger<T>.CreateChecked`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.ibinaryinteger-1). For example, you can compare a `byte` to an `int`:

```csharp
byte b = 10;
b.Should().Equal(10);   // int literal compared to byte
b.Should().NotEqual(256); // 256 can't fit in a byte → always passes
```

If the expected value can't be represented in the value's type (overflow), [`Equal`](API/MrKWatkins.Assertions/IntegerAssertions-T/Equal.md) throws an assertion failure with a descriptive message. [`NotEqual`](API/MrKWatkins.Assertions/IntegerAssertions-T/NotEqual.md) passes silently in this case.

## Decimal

[`DecimalAssertions`](API/MrKWatkins.Assertions/DecimalAssertions/index.md) is available for [`decimal`](https://learn.microsoft.com/en-us/dotnet/api/system.decimal) via `.Should()`. Because `decimal` is an exact type, there is no precision/approximation parameter — comparisons use exact values.

```csharp
(1.5m).Should().Equal(1.5m);
(1.5m).Should().NotEqual(2.0m);
(5m).Should().BePositive().And.BeLessThan(10m);
```

Equality uses the base [`Equal`](API/MrKWatkins.Assertions/ObjectAssertions-TSelf-T/Equal.md) and [`NotEqual`](API/MrKWatkins.Assertions/ObjectAssertions-TSelf-T/NotEqual.md).

## Floating-Point

[`FloatingPointAssertions<T>`](API/MrKWatkins.Assertions/FloatingPointAssertions-T/index.md) is available for [`Half`](https://learn.microsoft.com/en-us/dotnet/api/system.half), `float`, and `double` via `.Should()`.

### Approximate Equality

Floating-point comparisons should generally use [`BeApproximately`](API/MrKWatkins.Assertions/FloatingPointAssertions-T/BeApproximately.md) rather than `Equal`:

```csharp
double value = 1.0 / 3.0;
value.Should().BeApproximately(0.333, 0.001);

// Half works the same way
var halfValue = (Half)17.5;
halfValue.Should().BeApproximately((Half)17.5, (Half)0.1);
```

### Comparisons with Precision

As well as the exact comparisons above, there are comparison methods that take a precision parameter that defines a tolerance:

```csharp
double value = 5.001;
value.Should().BeGreaterThan(5.0, 0.0001);
value.Should().BeLessThan(6.0, 0.0001);
value.Should().BeGreaterThanOrEqualTo(5.001, 0.001);
value.Should().BeLessThanOrEqualTo(5.001, 0.001);
```

### NaN and Signed Zero

Comparisons, sign and zero assertions follow the behaviour of the comparison operators:

- [`NaN`](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan) is unordered, so it is not less than, greater than or equal to anything, and is not zero, positive or negative.
- `-0.0` is zero, and is not negative.

```csharp
double.NaN.Should().BeLessThan(1.0);   // Fails.
double.NaN.Should().NotBePositive();   // Passes.
(-0.0).Should().BeZero();              // Passes.
(-0.0).Should().BeNegative();          // Fails.
```

### Special Values

Uses [`IFloatingPoint<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.ifloatingpoint-1) members `IsNaN`, `IsInfinity`, `IsPositiveInfinity`, and `IsNegativeInfinity`:

```csharp
double.NaN.Should().BeNaN();
(1.0).Should().NotBeNaN();

double.PositiveInfinity.Should().BeInfinity();
double.NegativeInfinity.Should().BeInfinity();
(1.0).Should().NotBeInfinity();

double.PositiveInfinity.Should().BePositiveInfinity();
double.NegativeInfinity.Should().BeNegativeInfinity();
```

## Booleans

[`BooleanAssertions`](API/MrKWatkins.Assertions/BooleanAssertions/index.md) is available for `bool` via `.Should()`. For nullable booleans (`bool?`), use the extension methods from [`BooleanExtensions`](API/MrKWatkins.Assertions/BooleanExtensions/index.md).

```csharp
bool value = true;
value.Should().BeTrue();
value.Should().NotBeFalse();

bool other = false;
other.Should().BeFalse();
other.Should().NotBeTrue();
```

Nullable booleans:

```csharp
bool? nullable = true;
nullable.Should().BeTrue();   // fails if null or false
nullable.Should().NotBeFalse(); // passes if null or true

bool? nullValue = null;
nullValue.Should().NotBeTrue();  // passes — null is not true
nullValue.Should().NotBeFalse(); // passes — null is not false
```

## Integer Display Format

By default integers in assertion messages are displayed in decimal. Use [`With.IntegerFormat`](API/MrKWatkins.Assertions/With/IntegerFormat.md) to display them in hexadecimal within a scope:

```csharp
using (With.IntegerFormat(IntegerFormat.Hexadecimal))
{
    ((byte)255).Should().Equal(0); // message: "Value should equal 0x00 but was 0xFF."
}
```

[`With.IntegerFormat`](API/MrKWatkins.Assertions/With/IntegerFormat.md) returns an [`IDisposable`](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) that restores the previous format when disposed. See [`IntegerFormat`](API/MrKWatkins.Assertions/IntegerFormat/index.md) for the available formats.
