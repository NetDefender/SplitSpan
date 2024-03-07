using System;

namespace SplitSpan;

internal static class IntegerParser
{
    internal static int ParsePositiveInteger(ReadOnlySpan<char> source)
    {
        int result = 0;
        int tens = 1;

        for (int i = source.Length - 1; i >= 0; i--)
        {
            result += (source[i] - '0') * tens;
            tens *= 10;
        }

        return result;
    }
}