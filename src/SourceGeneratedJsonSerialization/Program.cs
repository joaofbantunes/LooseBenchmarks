using System.Text.Json;
using System.Text.Json.Serialization;
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
    private SomeRecordToSerialize[] _records = null!;

    [Params(1, 10, 100, 1_000, 10_000, 100_000)]
    public int N;

    [GlobalSetup]
    public void GlobalSetup()
        => _records = Enumerable
            .Range(0, N)
            .Select(i => new SomeRecordToSerialize(
                i,
                $"Some text {i}",
                DateOnly.FromDayNumber(i),
                Enumerable
                    .Range(0, 10)
                    .ToDictionary(j => $"Some Key {i}-{j}", j => $"Some Value {i}-{j}")))
            .ToArray();

    [Benchmark(Baseline = true)]
    public string NotSourceGenerated() => JsonSerializer.Serialize(_records);

    [Benchmark]
    public string SourceGenerated()
        => JsonSerializer.Serialize(_records, BenchmarkJsonSerializerContext.Default.SomeRecordToSerializeArray);
}

public record SomeRecordToSerialize(
    int Id,
    string Text,
    DateOnly Date,
    Dictionary<string, string> Map);

[JsonSerializable(typeof(SomeRecordToSerialize[]))]
[JsonSerializable(typeof(SomeRecordToSerialize))]
internal partial class BenchmarkJsonSerializerContext : JsonSerializerContext
{
}