# Verify.That Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [That(Boolean, String)](MrKWatkins.Assertions.Verify.That.md#mrkwatkins-assertions-verify-that(system-boolean-system-string)) | Verifies that the specified condition is `false`, throwing an assertion exception if it is `true`. |
| [That(Boolean, FormatInterpolatedStringHandler)](MrKWatkins.Assertions.Verify.That.md#mrkwatkins-assertions-verify-that(system-boolean-mrkwatkins-assertions-formatinterpolatedstringhandler)) | Verifies that the specified condition is `false`, throwing an assertion exception if it is `true`. |

## That(Boolean, String) {id="mrkwatkins-assertions-verify-that(system-boolean-system-string)"}

Verifies that the specified condition is `false`, throwing an assertion exception if it is `true`.

```c#
public static void That(bool condition, string exceptionMessage);
```

## Parameters {id="parameters-mrkwatkins-assertions-verify-that(system-boolean-system-string)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| condition | [Boolean](https://learn.microsoft.com/en-gb/dotnet/api/System.Boolean) | The condition to verify. The assertion fails if this is `true`. |
| exceptionMessage | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The message for the assertion exception if the condition is `true`. |

## That(Boolean, FormatInterpolatedStringHandler) {id="mrkwatkins-assertions-verify-that(system-boolean-mrkwatkins-assertions-formatinterpolatedstringhandler)"}

Verifies that the specified condition is `false`, throwing an assertion exception if it is `true`.

```c#
public static void That(bool condition, FormatInterpolatedStringHandler message);
```

## Parameters {id="parameters-mrkwatkins-assertions-verify-that(system-boolean-mrkwatkins-assertions-formatinterpolatedstringhandler)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| condition | [Boolean](https://learn.microsoft.com/en-gb/dotnet/api/System.Boolean) | The condition to verify. The assertion fails if this is `true`. |
| message | [FormatInterpolatedStringHandler](MrKWatkins.Assertions.FormatInterpolatedStringHandler.md) | The interpolated message for the assertion exception if the condition is `true`. |

