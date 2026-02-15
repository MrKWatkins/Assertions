# ActionAssertions.Throw Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Throw&lt;TException&gt;()](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1) | Asserts that the action throws an exception of the specified type. |
| [Throw&lt;TException&gt;(String)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(system-string)) | Asserts that the action throws an exception of the specified type with the specified message. |
| [Throw&lt;TException&gt;(String, Exception)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)) | Asserts that the action throws an exception of the specified type with the specified message and inner exception. |
| [Throw&lt;TException&gt;(TException)](MrKWatkins.Assertions.ActionAssertions.Throw.md#mrkwatkins-assertions-actionassertions-throw-1(-0)) | Asserts that the action throws the exact specified exception instance. |

## Throw&lt;TException&gt;() {id="mrkwatkins-assertions-actionassertions-throw-1"}

Asserts that the action throws an exception of the specified type.

```c#
public ActionAssertionsChain<TException> Throw<TException>()
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1"}

| Name | Description |
| ---- | ----------- |
| TException | The expected exception type. |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)

An [ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md) containing the thrown exception.
## Throw&lt;TException&gt;(String) {id="mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

Asserts that the action throws an exception of the specified type with the specified message.

```c#
public ActionAssertionsChain<TException> Throw<TException>(string expectedMessage)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

| Name | Description |
| ---- | ----------- |
| TException | The expected exception type. |

## Parameters {id="parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected exception message. |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1(system-string)"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)

An [ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md) containing the thrown exception.
## Throw&lt;TException&gt;(String, Exception) {id="mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

Asserts that the action throws an exception of the specified type with the specified message and inner exception.

```c#
public ActionAssertionsChain<TException> Throw<TException>(string expectedMessage, Exception? expectedInnerException)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

| Name | Description |
| ---- | ----------- |
| TException | The expected exception type. |

## Parameters {id="parameters-mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expectedMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The expected exception message. |
| expectedInnerException | [Exception](https://learn.microsoft.com/en-gb/dotnet/api/System.Exception) | The expected inner exception, or `null` to assert no inner exception. |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1(system-string-system-exception)"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)

An [ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md) containing the thrown exception.
## Throw&lt;TException&gt;(TException) {id="mrkwatkins-assertions-actionassertions-throw-1(-0)"}

Asserts that the action throws the exact specified exception instance.

```c#
public ActionAssertionsChain<TException> Throw<TException>(TException expected)
   where TException : Exception;
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-actionassertions-throw-1(-0)"}

| Name | Description |
| ---- | ----------- |
| TException | The expected exception type. |

## Parameters {id="parameters-mrkwatkins-assertions-actionassertions-throw-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| expected | TException | The expected exception instance. |

## Returns {id="returns-mrkwatkins-assertions-actionassertions-throw-1(-0)"}

[ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md)

An [ActionAssertionsChain&lt;TException&gt;](MrKWatkins.Assertions.ActionAssertionsChain-1.md) containing the thrown exception.
