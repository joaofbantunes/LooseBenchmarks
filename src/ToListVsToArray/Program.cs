using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    [Params(1, 10, 100, 1_000, 10_000, 100_000)]
    public int N;
    
    [Benchmark(Baseline = true)]
    public IReadOnlyCollection<int> ToList()
        => Enumerable.Range(0, N).ToList();

    [Benchmark]
    public IReadOnlyCollection<int> ToArray()
        => Enumerable.Range(0, N).ToArray();
    
}