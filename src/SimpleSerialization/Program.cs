// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Google.Protobuf;
using SimpleSerialization.Protobuf;

_ = BenchmarkRunner.Run<Benchmark>();

// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/source-generation

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    private List<ContextEntry> _jsonRecords = null!;
    private ContextEntryList _protobufRecords = null!;

    [Params(1, 10, 100, 1_000, 10_000, 100_000)]
    public int N;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _jsonRecords = Enumerable
            .Range(0, N)
            .Select(i => new ContextEntry($"Some key {i}", $"Some value {i}"))
            .ToList();

        _protobufRecords = new ContextEntryList();
        _protobufRecords.Entries.AddRange(_jsonRecords
            .Select(entry => new SimpleSerialization.Protobuf.ContextEntry
            {
                Key = entry.Key,
                Value = entry.Value
            }));
    }

    [Benchmark(Baseline = true)]
    public byte[] JsonNotSourceGenerated() => JsonSerializer.SerializeToUtf8Bytes(_jsonRecords);

    [Benchmark]
    public byte[] JsonSourceGenerated()
        => JsonSerializer.SerializeToUtf8Bytes(_jsonRecords, SourceGenerationContext.Default.ListContextEntry);

    [Benchmark]
    public byte[] ProtobufNotSourceGenerated() => _protobufRecords.ToByteArray();
}

public record struct ContextEntry(string Key, string Value);

[JsonSerializable(typeof(List<ContextEntry>))]
public partial class SourceGenerationContext : JsonSerializerContext;
