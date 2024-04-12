using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();


[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class Benchmark
{
    [Params(10, 100, 1_000, 10_000)] public int N;

    private string ToLookup { get; set; } = null!;
    private StronglyTypedKey ToLookupStronglyTyped { get; set; }
    private Dictionary<string, string> Traditional { get; set; } = null!;
    private Dictionary<StronglyTypedKey, string> TraditionalWithStronglyTypedKey { get; set; } = null!;
    private FrozenDictionary<string, string> Frozen { get; set; } = null!;
    private FrozenDictionary<StronglyTypedKey, string> FrozenWithStronglyTypedKey { get; set; } = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var contents = Enumerable.Range(0, N).Select(i => $"some-number-{i}").ToArray();
        ToLookup = contents.Last();
        ToLookupStronglyTyped = new StronglyTypedKey(ToLookup);
        Traditional = contents.ToDictionary(x => x, x => x);
        TraditionalWithStronglyTypedKey = contents.ToDictionary(x => new StronglyTypedKey(x), x => x);
        Frozen = Traditional.ToFrozenDictionary();
        FrozenWithStronglyTypedKey = TraditionalWithStronglyTypedKey.ToFrozenDictionary();
    }

    [Benchmark(Baseline = true)]
    public string LookupTraditional() => Traditional[ToLookup];

    [Benchmark]
    public string LookupTraditionalWithStronglyTypedKey() => TraditionalWithStronglyTypedKey[ToLookupStronglyTyped];

    [Benchmark]
    public string LookupFrozen() => Frozen[ToLookup];

    [Benchmark]
    public string LookupFrozenWithStronglyTypedKey() => FrozenWithStronglyTypedKey[ToLookupStronglyTyped];
}

public readonly record struct StronglyTypedKey(string Value);