using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams, BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    [Params(1, 10, 100, 1_000, 10_000)] public int N;

    private BaseImplementation<string> _string = null!;
    private BaseImplementation<int> _int = null!;
    private BaseImplementation<Guid> _guid = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _string = new BaseImplementation<string>(
            N,
            new StronglyTypedKeyEqualityComparerString(),
            i => $"some-string-key-for-the-dictionary-{i}");
        _int = new BaseImplementation<int>(
            N,
            new StronglyTypedKeyEqualityComparerInt(),
            i => i);
        _guid = new BaseImplementation<Guid>(
            N,
            new StronglyTypedKeyEqualityComparerGuid(),
            i => Guid.NewGuid());
    }

    [Benchmark(Baseline = true), BenchmarkCategory("string")]
    public string LookupTraditionalString() => _string.LookupTraditional();

    [Benchmark, BenchmarkCategory("string")]
    public string LookupTraditionalWithStronglyTypedKeyString()
        => _string.LookupTraditionalWithStronglyTypedKey();
    
    [Benchmark, BenchmarkCategory("string")]
    public string LookupTraditionalWithStronglyTypedKeyStringWithCustomComparer()
        => _string.LookupTraditionalWithStronglyTypedKeyWithCustomComparer();

    [Benchmark, BenchmarkCategory("string")]
    public string LookupFrozenString() => _string.LookupFrozen();

    [Benchmark, BenchmarkCategory("string")]
    public string LookupFrozenWithStronglyTypedKeyString()
        => _string.LookupFrozenWithStronglyTypedKey();
    
    [Benchmark, BenchmarkCategory("string")]
    public string LookupFrozenWithStronglyTypedKeyStringWithCustomComparer()
        => _string.LookupFrozenWithStronglyTypedKeyWithCustomComparer();

    [Benchmark(Baseline = true), BenchmarkCategory("int")]
    public string LookupTraditionalInt() => _int.LookupTraditional();

    [Benchmark, BenchmarkCategory("int")]
    public string LookupTraditionalWithStronglyTypedKeyInt()
        => _int.LookupTraditionalWithStronglyTypedKey();
    
    [Benchmark, BenchmarkCategory("int")]
    public string LookupTraditionalWithStronglyTypedKeyIntWithCustomComparer()
        => _int.LookupTraditionalWithStronglyTypedKeyWithCustomComparer();

    [Benchmark, BenchmarkCategory("int")]
    public string LookupFrozenInt() => _int.LookupFrozen();

    [Benchmark, BenchmarkCategory("int")]
    public string LookupFrozenWithStronglyTypedKeyInt()
        => _int.LookupFrozenWithStronglyTypedKey();
    
    [Benchmark, BenchmarkCategory("int")]
    public string LookupFrozenWithStronglyTypedKeyIntWithCustomComparer()
        => _int.LookupFrozenWithStronglyTypedKeyWithCustomComparer();

    [Benchmark(Baseline = true), BenchmarkCategory("guid")]
    public string LookupTraditionalGuid() => _guid.LookupTraditional();

    [Benchmark, BenchmarkCategory("guid")]
    public string LookupTraditionalWithStronglyTypedKeyGuid()
        => _guid.LookupTraditionalWithStronglyTypedKey();
    
    [Benchmark, BenchmarkCategory("guid")]
    public string LookupTraditionalWithStronglyTypedKeyGuidWithCustomComparer()
        => _guid.LookupTraditionalWithStronglyTypedKeyWithCustomComparer();

    [Benchmark, BenchmarkCategory("guid")]
    public string LookupFrozenGuid() => _guid.LookupFrozen();

    [Benchmark, BenchmarkCategory("guid")]
    public string LookupFrozenWithStronglyTypedKeyGuid()
        => _guid.LookupFrozenWithStronglyTypedKey();
    
    [Benchmark, BenchmarkCategory("guid")]
    public string LookupFrozenWithStronglyTypedKeyGuidWithCustomComparer()
        => _guid.LookupFrozenWithStronglyTypedKeyWithCustomComparer();
}

public readonly record struct StronglyTypedKey<T>(T Value);

public class StronglyTypedKeyEqualityComparerString : IEqualityComparer<StronglyTypedKey<string>>
{
    public bool Equals(StronglyTypedKey<string> x, StronglyTypedKey<string> y) => x.Value.Equals(y.Value);
    public int GetHashCode(StronglyTypedKey<string> obj) => obj.Value.GetHashCode();
}

public class StronglyTypedKeyEqualityComparerInt : IEqualityComparer<StronglyTypedKey<int>>
{
    public bool Equals(StronglyTypedKey<int> x, StronglyTypedKey<int> y) => x.Value.Equals(y.Value);
    public int GetHashCode(StronglyTypedKey<int> obj) => obj.Value.GetHashCode();
}

public class StronglyTypedKeyEqualityComparerGuid : IEqualityComparer<StronglyTypedKey<Guid>>
{
    public bool Equals(StronglyTypedKey<Guid> x, StronglyTypedKey<Guid> y) => x.Value.Equals(y.Value);
    public int GetHashCode(StronglyTypedKey<Guid> obj) => obj.Value.GetHashCode();
}

public class BaseImplementation<T> where T : notnull
{
    private readonly T _toLookup;
    private readonly StronglyTypedKey<T> _toLookupStronglyTyped;
    private readonly Dictionary<T, string> _traditional;
    private readonly Dictionary<StronglyTypedKey<T>, string> _traditionalWithStronglyTypedKey;
    private readonly Dictionary<StronglyTypedKey<T>, string> _traditionalWithStronglyTypedKeyWithCustomComparer;
    private readonly FrozenDictionary<T, string> _frozen;
    private readonly FrozenDictionary<StronglyTypedKey<T>, string> _frozenWithStronglyTypedKey;
    private readonly FrozenDictionary<StronglyTypedKey<T>, string> _frozenWithStronglyTypedKeyWithCustomComparer;

    public BaseImplementation(int n, IEqualityComparer<StronglyTypedKey<T>> equalityComparer, Func<int, T> factory)
    {
        var contents = Enumerable.Range(0, n).Select(factory).ToArray();
        _toLookup = contents.Last();
        _toLookupStronglyTyped = new StronglyTypedKey<T>(_toLookup);
        _traditional = contents.ToDictionary(x => x, x => x.ToString()!);
        _traditionalWithStronglyTypedKey = contents.ToDictionary(x => new StronglyTypedKey<T>(x), x => x.ToString()!);
        _traditionalWithStronglyTypedKeyWithCustomComparer =
            contents.ToDictionary(x => new StronglyTypedKey<T>(x), x => x.ToString()!, equalityComparer);
        _frozen = _traditional.ToFrozenDictionary();
        _frozenWithStronglyTypedKey = _traditionalWithStronglyTypedKey.ToFrozenDictionary();
        _frozenWithStronglyTypedKeyWithCustomComparer =
            _traditionalWithStronglyTypedKey.ToFrozenDictionary(equalityComparer);
    }

    public string LookupTraditional() => _traditional[_toLookup];

    public string LookupTraditionalWithStronglyTypedKey() => _traditionalWithStronglyTypedKey[_toLookupStronglyTyped];

    public string LookupTraditionalWithStronglyTypedKeyWithCustomComparer()
        => _traditionalWithStronglyTypedKeyWithCustomComparer[_toLookupStronglyTyped];

    public string LookupFrozen() => _frozen[_toLookup];

    public string LookupFrozenWithStronglyTypedKey() => _frozenWithStronglyTypedKey[_toLookupStronglyTyped];

    public string LookupFrozenWithStronglyTypedKeyWithCustomComparer()
        => _frozenWithStronglyTypedKeyWithCustomComparer[_toLookupStronglyTyped];
}