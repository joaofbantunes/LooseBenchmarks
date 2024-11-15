// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();

// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/source-generation

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    public object _value = (long)1;

    [Params(1, 10, 100, 1_000)] public int N;

    [Benchmark(Baseline = true)]
    public bool BuiltInConverter()
    {
        var result = false;
        for (var i = 0; i < N; i++)
        {
            result = Convert.ToBoolean(_value);
        }

        return result;
    }

    [Benchmark]
    public bool AdHoc()
    {
        var result = false;
        for (var i = 0; i < N; i++)
        {
            result = _value switch
            {
                long v => v == 1,
                int v => v == 1,
                _ => false
            };
        }

        return result;
    }
}