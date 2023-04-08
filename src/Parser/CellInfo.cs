using Parser.Enums;

namespace Parser;

public class CellInfo<T>
{
    public int Position { get; set; }

    public TypeEnum Type { get; set; } = TypeEnum.String;
    public Func<object, T?> SetValue { get; init; } = x => (T)x;
    public T? DefaultValue { get; set; } = default;
    public Func<object, T?> SetCorruptedValue { get; init; } = _ => default;
}