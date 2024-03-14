using System.Linq;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SplitSpan;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public partial class ParserBenchmarks
{
    private string _value;
    private Regex _splitRegex;

    [Params(10000)]
    public int Items;

    [GlobalSetup]
    public void Setup()
    {
        _splitRegex = new Regex("-", RegexOptions.Compiled);
        _value = string.Join("-", Enumerable.Range(Items, Items));
    }

    [Benchmark]
    public int SplitClassic()
    {
        int result = 0;
        foreach (string part in _value.Split('-'))
        {
            result = int.Parse(part);
        }

        return result;
    }

    [Benchmark]
    public int SplitRegex()
    {
        int result = 0;
        foreach (string part in _splitRegex.Split(_value))
        {
            result = int.Parse(part);
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public int SplitRefStruct()
    {
        int result = 0;
        Splitter splitter = new(_value, '-');
        while (splitter.NextToken())
        {
            result = IntegerParser.ParsePositiveInteger(splitter.Current());
        }

        return result;
    }

    [Benchmark]
    public int SplitEnumeratorStruct()
    {
        int result = 0;
        foreach(int number in new IntegerSplitter(_value, '-'))
        {
            result = number;
        }

        return result;
    }
}