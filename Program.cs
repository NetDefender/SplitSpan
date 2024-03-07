using BenchmarkDotNet.Running;

namespace SplitSpan;

internal static class Program
{
    static void Main() => BenchmarkRunner.Run<ParserBenchmarks>();
}