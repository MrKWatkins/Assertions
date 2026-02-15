# FormatInterpolatedStringHandler.AppendFormatted Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [AppendFormatted&lt;T&gt;(T)](MrKWatkins.Assertions.FormatInterpolatedStringHandler.AppendFormatted.md#mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(-0)) | Appends a formatted value to the message. |
| [AppendFormatted&lt;T&gt;(IEnumerable&lt;T&gt;)](MrKWatkins.Assertions.FormatInterpolatedStringHandler.AppendFormatted.md#mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(system-collections-generic-ienumerable((-0)))) | Appends a formatted enumerable to the message. |
| [AppendFormatted(String, String)](MrKWatkins.Assertions.FormatInterpolatedStringHandler.AppendFormatted.md#mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted(system-string-system-string)) | Appends a formatted string value to the message using the specified format. |

## AppendFormatted&lt;T&gt;(T) {id="mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(-0)"}

Appends a formatted value to the message.

```c#
public void AppendFormatted<T>(T? value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(-0)"}

| Name | Description |
| ---- | ----------- |
| T | The type of the value. |

## Parameters {id="parameters-mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(-0)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | T | The value to format and append. |

## AppendFormatted&lt;T&gt;(IEnumerable&lt;T&gt;) {id="mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(system-collections-generic-ienumerable((-0)))"}

Appends a formatted enumerable to the message.

```c#
public void AppendFormatted<T>(IEnumerable<T> value);
```

### Type Parameters {id="type-parameters-mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(system-collections-generic-ienumerable((-0)))"}

| Name | Description |
| ---- | ----------- |
| T | The type of elements in the enumerable. |

## Parameters {id="parameters-mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted-1(system-collections-generic-ienumerable((-0)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [IEnumerable&lt;T&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1) | The enumerable to format and append. |

## AppendFormatted(String, String) {id="mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted(system-string-system-string)"}

Appends a formatted string value to the message using the specified format.

```c#
public void AppendFormatted(string? value, string format);
```

## Parameters {id="parameters-mrkwatkins-assertions-formatinterpolatedstringhandler-appendformatted(system-string-system-string)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The string value to append. |
| format | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | The format specifier. Use &quot;L&quot; for literal (unquoted) output. |

