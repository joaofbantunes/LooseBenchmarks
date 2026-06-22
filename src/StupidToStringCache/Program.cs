using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class Benchmark
{
    [Params(1, 2, 5, 10, 100, 1_000)] public int N;

    private Guid Value { get; } = Guid.NewGuid();

    [Benchmark(Baseline = true)]
    public string[] Regular()
    {
        var result = new string[N];
        var regular = new RegularSampleRecord(Value);
        for (var i = 0; i < N; i++)
        {
            result[i] = regular.ToString();
        }

        return result;
    }

    [Benchmark]
    public string[] Cached()
    {
        var result = new string[N];
        var cached = new CachedSampleRecord(Value);
        for (var i = 0; i < N; i++)
        {
            result[i] = cached.ToString();
        }

        return result;
    }
}

public sealed record RegularSampleRecord(Guid Value)
{
    public override string ToString() => Value.ToString();
}

public sealed record CachedSampleRecord(Guid Value)
{
    private string? _string;
    public override string ToString() => _string ??= Value.ToString();
}