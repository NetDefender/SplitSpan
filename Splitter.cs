using System;

namespace SplitSpan;

public ref struct Splitter
{
    private readonly string _value;
    private readonly char _separator;
    private int _start;
    private int _end;
    private int _pos;

    public Splitter(string value, char separator)
    {
        _value = value;
        _separator = separator;
    }

    public bool NextToken()
    {
        if (_pos < _value.Length)
        {
            int next = _value.IndexOf(_separator, _pos);
            _start = _pos;

            if (next < 0)
            {
                _end = _value.Length - 1;
                _pos = _value.Length;
            }
            else
            {
                _end = next - 1;
                _pos = next + 1;
            }

            return true;
        }

        return false;
    }

    public readonly ReadOnlySpan<char> Current() => _value.AsSpan(_start, _end - _start + 1);
}