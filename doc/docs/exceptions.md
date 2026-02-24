# Exceptions

There are three ways to assert on exceptions, depending on whether the code under test is synchronous or asynchronous, and whether you already have an exception instance.

## Actions (Synchronous)

Call `.Should()` on an [`Action`](https://learn.microsoft.com/en-us/dotnet/api/system.action) to get [`ActionAssertions`](API/MrKWatkins.Assertions/ActionAssertions/index.md):

```csharp
Action throws = () => throw new InvalidOperationException("oops");

throws.Should().Throw<InvalidOperationException>();
```

Assert that no exception is thrown:

```csharp
Action safe = () => { /* ... */ };
safe.Should().NotThrow();
```

### Asserting the Message

```csharp
throws.Should().Throw<InvalidOperationException>("oops");
```

### Asserting Message and Inner Exception

```csharp
var inner = new Exception("inner");
Action nested = () => throw new InvalidOperationException("outer", inner);

nested.Should().Throw<InvalidOperationException>("outer", inner);
```

### Asserting a Specific Exception Instance

```csharp
var expected = new InvalidOperationException("oops");
Action throws = () => throw expected;

throws.Should().Throw(expected);
```

### ArgumentException Shorthand

```csharp
Action badArg = () => throw new ArgumentException("must be positive", "count");

badArg.Should().ThrowArgumentException("must be positive", "count");
```

See [`ThrowArgumentException`](API/MrKWatkins.Assertions/ActionAssertions/ThrowArgumentException.md).

### ArgumentOutOfRangeException Shorthand

```csharp
Action outOfRange = () => throw new ArgumentOutOfRangeException("count", -1, "must be positive");

outOfRange.Should().ThrowArgumentOutOfRangeException("must be positive", "count", -1);
```

See [`ThrowArgumentOutOfRangeException`](API/MrKWatkins.Assertions/ActionAssertions/ThrowArgumentOutOfRangeException.md).

## Async Actions

Call `.Should()` on a [`Func<Task>`](https://learn.microsoft.com/en-us/dotnet/api/system.func-1) to get [`AsyncActionAssertions`](API/MrKWatkins.Assertions/AsyncActionAssertions/index.md). All methods return [`Task`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) and should be awaited:

```csharp
Func<Task> throwsAsync = async () =>
{
    await Task.Delay(1);
    throw new InvalidOperationException("oops");
};

await throwsAsync.Should().ThrowAsync<InvalidOperationException>();
await throwsAsync.Should().ThrowAsync<InvalidOperationException>("oops");
await throwsAsync.Should().ThrowArgumentExceptionAsync("bad arg", "paramName");
await throwsAsync.Should().ThrowArgumentOutOfRangeExceptionAsync("out of range", "paramName", -1);

Func<Task> safeAsync = async () => await Task.Delay(1);
await safeAsync.Should().NotThrowAsync();
```

## The Invoking / Awaiting Pattern

Use [`Invoking`](API/MrKWatkins.Assertions/InvokingExtensions/Invoking.md) and [`Awaiting`](API/MrKWatkins.Assertions/InvokingExtensions/Awaiting.md) extension methods from [`InvokingExtensions`](API/MrKWatkins.Assertions/InvokingExtensions/index.md) to test methods on an object without creating a separate `Action` variable:

```csharp
var parser = new Parser();

// Synchronous
parser.Invoking(p => p.Parse(null!))
    .Should().ThrowArgumentException("Value cannot be null", "input");

// Async
await parser.Awaiting(p => p.ParseAsync(null!))
    .Should().ThrowArgumentExceptionAsync("Value cannot be null", "input");
```

If the method returns a value, use the overloads that discard the result:

```csharp
parser.Invoking(p => p.TryParse(null!, out _))
    .Should().NotThrow();
```

## Asserting on an Exception Directly

Call `.Should()` on an [`Exception`](https://learn.microsoft.com/en-us/dotnet/api/system.exception) instance to get [`ExceptionAssertions<T>`](API/MrKWatkins.Assertions/ExceptionAssertions-T/index.md):

```csharp
var exception = new InvalidOperationException("oops");

exception.Should().HaveMessage("oops");
exception.Should().NotHaveMessage("something else");
exception.Should().HaveMessageStartingWith("oo");
```

### Inner Exceptions

```csharp
var inner = new ArgumentException("inner");
var outer = new InvalidOperationException("outer", inner);

outer.Should().HaveInnerException<ArgumentException>().And.HaveMessage("inner");

// Assert a specific instance
outer.Should().HaveInnerException(inner);

// Assert no inner exception
new Exception("no inner").Should().NotHaveInnerException();
```

See [`HaveInnerException`](API/MrKWatkins.Assertions/ExceptionAssertions-T/HaveInnerException.md) and [`NotHaveInnerException`](API/MrKWatkins.Assertions/ExceptionAssertions-T/NotHaveInnerException.md).

### Chaining After Throw

[`Throw<T>`](API/MrKWatkins.Assertions/ActionAssertions/Throw.md) and [`ThrowAsync<T>`](API/MrKWatkins.Assertions/AsyncActionAssertions/ThrowAsync.md) return an [`ActionAssertionsChain<TException>`](API/MrKWatkins.Assertions/ActionAssertionsChain-TException/index.md) with `.Exception` and `.That` properties for further assertions:

```csharp
var chain = throws.Should().Throw<ArgumentException>();

// .Exception gives the thrown exception
chain.Exception.Should().HaveMessage("bad argument");

// .That gives ExceptionAssertions<T> directly for chaining
throws.Should().Throw<ArgumentException>()
    .And.HaveMessage("bad argument")
    .And.HaveParamName("value");
```
