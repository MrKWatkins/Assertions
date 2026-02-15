# AGENTS.md

This file provides guidance to AI agents when working with code in this repository.

## Project Overview

MrKWatkins.Assertions is a .NET assertion library for unit testing, created as an MIT-licensed alternative to FluentAssertions. Key differentiators: Span support and strict ordering by default.

## Build & Test Commands

```bash
# Build
dotnet build src/Assertions.sln

# Run all tests
dotnet test src/Assertions.sln

# Run a single test by name filter
dotnet test src/MrKWatkins.Assertions.Tests --filter "FullyQualifiedName~TestMethodName"
```

## Architecture

**Single namespace:** `MrKWatkins.Assertions` — everything is in one namespace.

**Three entry points for assertions:**
- `value.Should()` — fluent API via `ShouldExtensions` (primary usage)
- `AssertThat.Invoking(() => action())` — action/exception testing
- `Verify.That(condition, message)` — direct verification

**Assertion class hierarchy:**
- `ObjectAssertions<T>` — base: null checks, equality, type checking
- `StringAssertions` — Contain, NotContain
- `EnumerableAssertions<TEnumerable, T>` — SequenceEqual, OnlyContain, ContainSingle
- `ReadOnlyDictionaryAssertions<TDict, TKey, TValue>` — dictionary assertions
- `ReadOnlySpanAssertions<T>` — span assertions (ref struct, zero-allocation)
- `ExceptionAssertions<T>` — HaveMessage, HaveInnerException
- `ActionAssertions` — Throw, NotThrow

**Fluent chaining:** Each assertion class has a corresponding `*Chain` class that wraps the value and enables `.And` chaining (e.g., `value.Should().NotBeNull().And.Equal(expected)`).

**Standalone extension methods** for simple types: `BooleanExtensions`, `NumericExtensions`, `CountExtensions`, `EnumerableExtensions`, `InvokingExtensions`.

**Formatting:** `Format.cs` handles value representation in error messages. `FormatInterpolatedStringHandler` provides custom interpolation. `With.IntegerFormat()` configures integer display via `FormattingScope`.

**Exception handling:** `Verify.cs` dynamically detects NUnit at runtime and throws its `AssertionException` when available, otherwise throws `AssertionException`.

## Conventions

- **Target:** .NET 10.0 with C# preview language features
- **Nullable reference types:** enabled; warnings are errors
- **Implicit usings** include `System.Diagnostics.CodeAnalysis`, `System.Diagnostics.Contracts`, `Pure` (aliased), and `JetBrains.Annotations`
- **JetBrains.Annotations:** Use `[Pure]`, `[NoEnumeration]`, `[InstantHandle]` etc. on public API methods
- **CallerArgumentExpression:** Used for predicate parameter logging
- **OverloadResolutionPriority:** Used to disambiguate generic overloads
- **Test framework:** TUnit (not NUnit/xUnit) — tests are async by default
- **Test naming:** Underscores in test method names (CA1707 suppressed)
- **Centralized package management:** versions in `src/Directory.Packages.props`, no version overrides allowed
- **Editor:** 4-space indents, LF line endings, max 200 char line length
- **Documentation:** XML comments on public API, Markdown for the API is automatically generated
