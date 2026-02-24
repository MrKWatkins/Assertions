# Objects

[`ObjectAssertions<T>`](API/MrKWatkins.Assertions/ObjectAssertions-T/index.md) is the base assertion class, available for any type via `.Should()`.

## Null Checks

```csharp
string? value = null;

value.Should().BeNull();

string nonNull = "hello";
nonNull.Should().NotBeNull();
```

[`NotBeNull()`](API/MrKWatkins.Assertions/ObjectAssertions-T/NotBeNull.md) returns an [`ObjectAssertionsChain<T>`](API/MrKWatkins.Assertions/ObjectAssertionsChain-T/index.md) so you can continue asserting:

```csharp
string? maybeNull = GetValue();
maybeNull.Should().NotBeNull().And.Equal("expected");
```

## Equality

Assert equality using the default [`EqualityComparer<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.equalitycomparer-1):

```csharp
"hello".Should().Equal("hello");
"hello".Should().NotEqual("world");
```

Pass a custom [`IEqualityComparer<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1):

```csharp
"Hello".Should().Equal("hello", StringComparer.OrdinalIgnoreCase);
```

Or a predicate:

```csharp
myObj.Should().Equal(other, (a, b) => a.Id == b.Id);
```

See [`Equal`](API/MrKWatkins.Assertions/ObjectAssertions-T/Equal.md) and [`NotEqual`](API/MrKWatkins.Assertions/ObjectAssertions-T/NotEqual.md) for full overload details.

## Reference Equality

Check whether two variables point to the same object instance:

```csharp
var a = new object();
var b = a;
var c = new object();

a.Should().BeTheSameInstanceAs(b);
a.Should().NotBeTheSameInstanceAs(c);
```

## Type Checks

Assert that a value is of a specific type (using [`IsAssignableTo`](https://learn.microsoft.com/en-us/dotnet/api/system.type.isassignableto), so subtypes pass):

```csharp
object value = "hello";
value.Should().BeOfType<string>();

// Returns a chain typed to the asserted type
value.Should().BeOfType<string>().And.Equal("hello");
```

Assert that a value is *not* of a type:

```csharp
object value = 42;
value.Should().NotBeOfType<string>();
```

See [`BeOfType`](API/MrKWatkins.Assertions/ObjectAssertions-T/BeOfType.md) and [`NotBeOfType`](API/MrKWatkins.Assertions/ObjectAssertions-T/NotBeOfType.md).
