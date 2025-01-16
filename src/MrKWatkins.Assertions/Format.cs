namespace MrKWatkins.Assertions;

internal static class Format
{
    [Pure]
    internal static string Value<T>(T value)
    {
        if (value is null)
        {
            return "null";
        }

        return value switch
        {
            string stringValue => $"\"{stringValue}\"",
            Type typeValue => typeValue.Name,
            _ => value.ToString()!
        };
    }
}