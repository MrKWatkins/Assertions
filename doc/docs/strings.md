# Strings

[`StringAssertions`](API/MrKWatkins.Assertions/StringAssertions/index.md) provides assertions for [`string`](https://learn.microsoft.com/en-us/dotnet/api/system.string) values. Obtain one via `.Should()` on any string.

String comparison methods default to [`StringComparison.Ordinal`](https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison). Pass an alternative [`StringComparison`](https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison) to any method that accepts one.

## Null and Empty

```csharp
string? value = null;

// Requires null
value.Should().BeNull();

// Requires null or empty (does not chain)
value.Should().BeNullOrEmpty();

// Requires null, empty, or whitespace (does not chain)
value.Should().BeNullOrWhiteSpace();

// Requires non-null and non-empty
"hello".Should().NotBeNullOrEmpty();

// Requires non-null, non-empty, non-whitespace
"hello".Should().NotBeNullOrWhiteSpace();

// Requires non-null and length == 0
"".Should().BeEmpty();

// Requires non-null and length > 0
"hello".Should().NotBeEmpty();
```

## Length

```csharp
"hello".Should().HaveLength(5);
"hello".Should().NotHaveLength(3);
```

## Substring and Prefix/Suffix

```csharp
"Hello, World!".Should().Contain("World");
"Hello, World!".Should().NotContain("Goodbye");

"Hello, World!".Should().StartWith("Hello");
"Hello, World!".Should().NotStartWith("Goodbye");

"Hello, World!".Should().EndWith("World!");
"Hello, World!".Should().NotEndWith("Hello");
```

Case-insensitive comparison:

```csharp
"Hello, World!".Should().Contain("world", StringComparison.OrdinalIgnoreCase);
"Hello, World!".Should().StartWith("hello", StringComparison.OrdinalIgnoreCase);
```

## Regular Expressions

```csharp
"abc123".Should().Match(@"\d+");
"abcdef".Should().NotMatch(@"\d+");
```

## Chaining

Chainable methods return a [`StringAssertionsChain`](API/MrKWatkins.Assertions/StringAssertionsChain/index.md):

```csharp
"Hello, World!"
    .Should()
    .NotBeNullOrEmpty()
    .And.StartWith("Hello")
    .And.EndWith("World!")
    .And.HaveLength(13);
```
