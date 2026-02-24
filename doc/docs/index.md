# MrKWatkins.Assertions

[![Build Status](https://github.com/MrKWatkins/Assertions/actions/workflows/build.yml/badge.svg)](https://github.com/MrKWatkins/Assertions/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.Assertions)](https://www.nuget.org/packages/MrKWatkins.Assertions)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.Assertions)](https://www.nuget.org/packages/MrKWatkins.Assertions)

> A fluent assertion library for .NET unit testing.

## Installation

```
dotnet add package MrKWatkins.Assertions
```

Everything is in the `MrKWatkins.Assertions` namespace:

```csharp
using MrKWatkins.Assertions;
```

## Quick Start

Call `.Should()` on any value to begin a fluent assertion:

```csharp
// Equality
42.Should().Equal(42);
"hello".Should().Equal("hello");

// Null checks
string? value = null;
value.Should().BeNull();

// Collections
var numbers = new[] { 1, 2, 3 };
numbers.Should().SequenceEqual(1, 2, 3);
numbers.Should().Contain(2);

// Strings
"Hello, World!".Should().StartWith("Hello").And.Contain("World");

// Exceptions
(() => throw new InvalidOperationException("oops"))
    .Should().Throw<InvalidOperationException>()
    .WithMessage("oops");
```

## Chaining

Most assertions return a chain object that lets you keep asserting on the same value:

```csharp
"hello world"
    .Should()
    .NotBeNull()
    .And.StartWith("hello")
    .And.EndWith("world")
    .And.HaveLength(11);
```

## Why?

FluentAssertions recently moved to a paid licence model with version 8.0. Whilst I don't have a particular problem with that, I am slightly annoyed by how they did it.
Instead of making a new package, they simply upgraded the version number and changed the licence. Which means any processes you might have in place to automatically
upgrade packages would then upgrade them and potentially leave you open to licencing costs. And yes, of course you should check your upgrades, blah blah, but I would
counter that with you shouldn't change licences on projects like that! Start a new package. Or something else. Whatever. Be better.

Anyway, it annoyed me enough that I thought I'd have a crack at my own version for a challenge and to see if I can fix a few irritations I have with FluentAssertions
on the way, such as:

* No Span support.
* Default ordering is not strict.

As such, this is purely designed for use in my other projects. If you want to use it, go for it, but don't expect me to fix bugs or add features anytime soon.

# Contributing, PRs, etc.

Not accepting contributions or PRs at the current time, as it's just a project for my own amusement and to support my other projects. Feel free to submit issues,
just don't expect me to look at them with any sense of urgency.

# Licence

MIT. And I won't change it. Honest.
