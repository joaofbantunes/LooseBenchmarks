using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

// sanity check
EnsureSetupCorrectness();

_ = BenchmarkRunner.Run<Benchmark>();

void EnsureSetupCorrectness()
{
    var b = new Benchmark
    {
        N = 1
    };
    b.GlobalSetup();
    if (b.IfWeAlreadyHadTheKey() != "some-stuff"
        || b.AllocateAndLookup() != "some-stuff"
        || b.TupleAndLookup() != "some-stuff"
        || b.DoubleLookup() != "some-stuff"
        || b.SpanConcatAndAlternateLookup() != "some-stuff")
    {
        throw new InvalidOperationException("Something's wrong!");
    }
}

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams, BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    private string _firstPartKey = nameof(_firstPartKey);
    private string _secondPartKey = nameof(_secondPartKey);
    private string _completeKey = null!;
    private FrozenDictionary<string, string> _completeMap = null!;
    private FrozenDictionary<string, string>.AlternateLookup<ReadOnlySpan<char>> _completeMapAlternateLookup;
    private FrozenDictionary<(string, string), string> _completeTupleMap = null!;
    private FrozenDictionary<string, FrozenDictionary<string, string>> _doubleMap = null!;

    [Params(1, 10, 100, 1_000)] public int N;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _completeKey = _firstPartKey + _secondPartKey;
        var completeMap = new Dictionary<string, string>();
        var completeTupleMap = new Dictionary<(string, string), string>();
        var doubleMap = new Dictionary<string, Dictionary<string, string>>();
        
        for (var i = 0; i < N; i++)
        {
            var secondPartMap = new Dictionary<string, string>();
            for (var j = 0; j < N; j++)
            {
                completeMap.Add($"{_firstPartKey}{i}{_secondPartKey}{j}", "some-stuff");
                completeTupleMap.Add(($"{_firstPartKey}{i}", $"{_secondPartKey}{j}"), "some-stuff");
                secondPartMap.Add($"{_secondPartKey}{j}", "some-stuff");
            }

            doubleMap.Add($"{_firstPartKey}{i}", secondPartMap);
        }

        // to ensure this weird logic is working as expected
        if (completeMap.Count != doubleMap.Count * doubleMap.First().Value.Count)
        {
            throw new InvalidOperationException("Something's wrong!");
        }

        completeMap.Add(_firstPartKey + _secondPartKey, "some-stuff");
        completeTupleMap.Add((_firstPartKey, _secondPartKey), "some-stuff");
        doubleMap.Add(_firstPartKey, new (doubleMap.First().Value)
        {
            { _secondPartKey, "some-stuff" }
        });

        _completeMap = completeMap.ToFrozenDictionary();
        _completeMapAlternateLookup = _completeMap.GetAlternateLookup<ReadOnlySpan<char>>();
        _completeTupleMap = completeTupleMap.ToFrozenDictionary();
        _doubleMap = doubleMap.ToFrozenDictionary(x => x.Key, x => x.Value.ToFrozenDictionary());
    }

    [Benchmark(Baseline = true)]
    public string IfWeAlreadyHadTheKey() => _completeMap[_completeKey];

    [Benchmark]
    public string AllocateAndLookup() => _completeMap[_firstPartKey + _secondPartKey];
    
    [Benchmark]
    public string TupleAndLookup() => _completeTupleMap[(_firstPartKey, _secondPartKey)];

    [Benchmark]
    public string DoubleLookup() => _doubleMap[_firstPartKey][_secondPartKey];

    [Benchmark]
    public string SpanConcatAndAlternateLookup()
    {
        Span<char> span = stackalloc char[_firstPartKey.Length + _secondPartKey.Length];
        _firstPartKey.AsSpan().CopyTo(span);
        _secondPartKey.AsSpan().CopyTo(span[_firstPartKey.Length..]);
        return _completeMapAlternateLookup[span];
    }
}