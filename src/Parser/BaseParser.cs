using System.Collections;
using Parser.Enums;

namespace Parser;

public abstract class BaseParser<TEntity> : IDisposable
    where TEntity: class, new()
{
    private readonly FileStream  _stream;

    private readonly ReadMode _mode;

    private readonly Dictionary<string, CellInfo<dynamic>> _sourcesPattern = new();

    private readonly int _firstRow;

    protected BaseParser(string path, ReadMode mode, int firstRow = 0)
    {
        _mode = mode;
        _firstRow = firstRow;
        _stream = File.OpenRead(path);
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}