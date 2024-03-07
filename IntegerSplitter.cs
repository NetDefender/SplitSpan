using System;
using System.Collections;
using System.Collections.Generic;

namespace SplitSpan;

public struct IntegerSplitter : IEnumerable<int>, IEnumerator<int>
{
    private readonly string _value;
    private readonly char _separator;
    private int _pos;
    private int _current;

    public IntegerSplitter(string value, char separator)
    {
        _value = value;
        _separator = separator;
    }

    public readonly IEnumerator<int> GetEnumerator() => this;

    readonly IEnumerator IEnumerable.GetEnumerator() => this;

    readonly int IEnumerator<int>.Current => _current;

    readonly object IEnumerator.Current => _current;

    public bool MoveNext()
    {
        if (_pos < _value.Length)
        {
            int next = _value.IndexOf(_separator, _pos);

            if (next >= 0)
            {
                _current = IntegerParser.ParsePositiveInteger(_value.AsSpan(_pos, next - _pos));
                _pos = next + 1;
            }
            else
            {
                _current = IntegerParser.ParsePositiveInteger(_value.AsSpan(_pos, _value.Length - _pos));
                _pos = _value.Length;
            }

            return true;
        }

        return false;
    }

    public void Reset()
    {
        _current = _pos = 0;
    }

    public readonly void Dispose()
    {
    }
}