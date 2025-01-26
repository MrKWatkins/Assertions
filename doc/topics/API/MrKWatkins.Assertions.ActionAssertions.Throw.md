# ActionAssertions.Throw Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Throw&lt;TException&gt;()](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1) |  |
| [Throw&lt;TException&gt;(String)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(system-string)) |  |
| [Throw&lt;TException&gt;(String, Exception)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)) |  |
| [Throw&lt;TException&gt;(TException)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(-0)) |  |

## Throw&lt;TException&gt;() {id="mrkwatkins-assertions-actionassertions-throw-1"}

```c#
public ActionAssertionsChain<TException> Throw<TException>()
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1"}

| Name | Description |
| ---- | ----------- |
| TException |  |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)
## Throw&lt;TException&gt;(String) {id="mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

```c#
public ActionAssertionsChain<TException> Throw<TException>(string expectedMessage)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters {id="parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) |  |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)
## Throw&lt;TException&gt;(String, Exception) {id="mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

```c#
public ActionAssertionsChain<TException> Throw<TException>(string expectedMessage, Exception? expectedInnerException)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters {id="parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) |  |
| expectedInnerException | [Exception](https://learn.microsoft.com/en-gb/dotnet/api/System.Exception) |  |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)
## Throw&lt;TException&gt;(TException) {id="mrkwatkins-assertions-actionassertions-throw-1(-0)"}

```c#
public ActionAssertionsChain<TException> Throw<TException>(TException expected)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1(-0)"}

| Name | Description |
| ---- | ----------- |
| TException |  |

## Parameters {id="parameters-mrkwatkins-assertions-actionassertions-throw-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | TException |  |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1(-0)"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)
