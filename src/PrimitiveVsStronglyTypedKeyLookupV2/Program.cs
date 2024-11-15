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
    private GuidImplementation _guid = null!;
    private IntImplementation _int = null!;
    private StringImplementation _string = null!;
    
    [Params(1, 10, 100, 1_000, 10_000)] public int N;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _string = new StringImplementation(N);
        _int = new IntImplementation(N);
        _guid = new GuidImplementation(N);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("string")]
    public string LookupString() => _string.Lookup();

    [Benchmark]
    [BenchmarkCategory("string")]
    public string LookupWithStronglyTypedKeyString() => _string.LookupStrong();

    [Benchmark]
    [BenchmarkCategory("string")]
    public string LookupWithStronglyTypedKeyStringWithCustomComparer() => _string.LookupWithStrongCustomComparer();

    [Benchmark]
    [BenchmarkCategory("string")]
    public string LookupWithRefStronglyTypedKeyString() => _string.LookupRefStrong();

    [Benchmark]
    [BenchmarkCategory("string")]
    public string LookupWithRefStronglyTypedKeyStringWithCustomComparer() => _string.LookupRefStrongCustomComparer();

    [Benchmark]
    [BenchmarkCategory("string")]
    public string LookupWithGenericStronglyTypedKeyString() => _string.LookupWithGenericStrong();

    [Benchmark]
    [BenchmarkCategory("string")]
    public string LookupWithGenericStronglyTypedKeyStringWithCustomComparer() => _string.LookupGenericStrongCustomComparer();


    [Benchmark(Baseline = true)]
    [BenchmarkCategory("int")]
    public string LookupInt() => _int.Lookup();

    [Benchmark]
    [BenchmarkCategory("int")]
    public string LookupWithStronglyTypedKeyInt() => _int.LookupStrong();

    [Benchmark]
    [BenchmarkCategory("int")]
    public string LookupWithStronglyTypedKeyIntWithCustomComparer() => _int.LookupWithStrongCustomComparer();

    [Benchmark]
    [BenchmarkCategory("int")]
    public string LookupWithRefStronglyTypedKeyInt() => _int.LookupRefStrong();

    [Benchmark]
    [BenchmarkCategory("int")]
    public string LookupWithRefStronglyTypedKeyIntWithCustomComparer() => _int.LookupRefStrongCustomComparer();

    [Benchmark]
    [BenchmarkCategory("int")]
    public string LookupWithGenericStronglyTypedKeyInt() => _int.LookupWithGenericStrong();

    [Benchmark]
    [BenchmarkCategory("int")]
    public string LookupWithGenericStronglyTypedKeyIntWithCustomComparer() => _int.LookupGenericStrongCustomComparer();


    [Benchmark(Baseline = true)]
    [BenchmarkCategory("guid")]
    public string LookupGuid() => _guid.Lookup();

    [Benchmark]
    [BenchmarkCategory("guid")]
    public string LookupWithStronglyTypedKeyGuid() => _guid.LookupStrong();

    [Benchmark]
    [BenchmarkCategory("guid")]
    public string LookupWithStronglyTypedKeyGuidWithCustomComparer() => _guid.LookupWithStrongCustomComparer();

    [Benchmark]
    [BenchmarkCategory("guid")]
    public string LookupWithRefStronglyTypedKeyGuid() => _guid.LookupRefStrong();

    [Benchmark]
    [BenchmarkCategory("guid")]
    public string LookupWithRefStronglyTypedKeyGuidWithCustomComparer() => _guid.LookupRefStrongCustomComparer();

    [Benchmark]
    [BenchmarkCategory("guid")]
    public string LookupWithGenericStronglyTypedKeyGuid() => _guid.LookupWithGenericStrong();

    [Benchmark]
    [BenchmarkCategory("guid")]
    public string LookupWithGenericStronglyTypedKeyGuidWithCustomComparer() => _guid.LookupGenericStrongCustomComparer();
}

public readonly record struct GenericStronglyTypedKey<T>(T Value);

public readonly record struct StronglyTypedInt(int Value);

public readonly record struct StronglyTypedGuid(Guid Value);

public readonly record struct StronglyTypedString(string Value);

public sealed record ReferenceStronglyTypedInt(int Value);

public sealed record ReferenceStronglyTypedGuid(Guid Value);

public sealed record ReferenceStronglyTypedString(string Value);

public class GenericStronglyTypedKeyEqualityComparerString : IEqualityComparer<GenericStronglyTypedKey<string>>
{
    public bool Equals(GenericStronglyTypedKey<string> x, GenericStronglyTypedKey<string> y) => x.Value.Equals(y.Value);

    public int GetHashCode(GenericStronglyTypedKey<string> obj) => obj.Value.GetHashCode();
}

public class GenericStronglyTypedKeyEqualityComparerInt : IEqualityComparer<GenericStronglyTypedKey<int>>
{
    public bool Equals(GenericStronglyTypedKey<int> x, GenericStronglyTypedKey<int> y) => x.Value.Equals(y.Value);

    public int GetHashCode(GenericStronglyTypedKey<int> obj) => obj.Value.GetHashCode();
}

public class GenericStronglyTypedKeyEqualityComparerGuid : IEqualityComparer<GenericStronglyTypedKey<Guid>>
{
    public bool Equals(GenericStronglyTypedKey<Guid> x, GenericStronglyTypedKey<Guid> y) => x.Value.Equals(y.Value);

    public int GetHashCode(GenericStronglyTypedKey<Guid> obj) => obj.Value.GetHashCode();
}

public class StronglyTypedKeyEqualityComparerString : IEqualityComparer<StronglyTypedString>
{
    public bool Equals(StronglyTypedString x, StronglyTypedString y) => x.Value.Equals(y.Value);

    public int GetHashCode(StronglyTypedString obj) => obj.Value.GetHashCode();
}

public class StronglyTypedKeyEqualityComparerInt : IEqualityComparer<StronglyTypedInt>
{
    public bool Equals(StronglyTypedInt x, StronglyTypedInt y) => x.Value.Equals(y.Value);

    public int GetHashCode(StronglyTypedInt obj) => obj.Value.GetHashCode();
}

public class StronglyTypedKeyEqualityComparerGuid : IEqualityComparer<StronglyTypedGuid>
{
    public bool Equals(StronglyTypedGuid x, StronglyTypedGuid y) => x.Value.Equals(y.Value);

    public int GetHashCode(StronglyTypedGuid obj) => obj.Value.GetHashCode();
}

public class ReferenceStronglyTypedKeyEqualityComparerString : IEqualityComparer<ReferenceStronglyTypedString>
{
    public bool Equals(ReferenceStronglyTypedString? x, ReferenceStronglyTypedString? y) => x?.Value.Equals(y?.Value) ?? false;

    public int GetHashCode(ReferenceStronglyTypedString obj) => obj.Value.GetHashCode();
}

public class ReferenceStronglyTypedKeyEqualityComparerInt : IEqualityComparer<ReferenceStronglyTypedInt>
{
    public bool Equals(ReferenceStronglyTypedInt? x, ReferenceStronglyTypedInt? y) => x?.Value.Equals(y?.Value) ?? false;

    public int GetHashCode(ReferenceStronglyTypedInt obj) => obj.Value.GetHashCode();
}

public class ReferenceStronglyTypedKeyEqualityComparerGuid : IEqualityComparer<ReferenceStronglyTypedGuid>
{
    public bool Equals(ReferenceStronglyTypedGuid? x, ReferenceStronglyTypedGuid? y) => x?.Value.Equals(y?.Value) ?? false;

    public int GetHashCode(ReferenceStronglyTypedGuid obj) => obj.Value.GetHashCode();
}

public interface IBenchmarks
{
    string Lookup();
    string LookupStrong();
    string LookupWithStrongCustomComparer();
    string LookupRefStrong();
    string LookupRefStrongCustomComparer();
    string LookupWithGenericStrong();
    string LookupGenericStrongCustomComparer();
}

public class IntImplementation : IBenchmarks
{
    private readonly Dictionary<int, string> _primitive;
    private readonly int _toLookup;
    private readonly GenericStronglyTypedKey<int> _toLookupGenericStrong;
    private readonly ReferenceStronglyTypedInt _toLookupRefStrong;
    private readonly StronglyTypedInt _toLookupStrong;
    private readonly Dictionary<GenericStronglyTypedKey<int>, string> _withGenericStrong;
    private readonly Dictionary<GenericStronglyTypedKey<int>, string> _withGenericStrongWithCustomComparer;
    private readonly Dictionary<ReferenceStronglyTypedInt, string> _withRefStrong;
    private readonly Dictionary<ReferenceStronglyTypedInt, string> _withRefStrongWithCustomComparer;
    private readonly Dictionary<StronglyTypedInt, string> _withStrong;
    private readonly Dictionary<StronglyTypedInt, string> _withStrongWithCustomComparer;

    public IntImplementation(int n)
    {
        var contents = Enumerable.Range(0, n).Select(i => i).ToArray();
        _toLookup = contents.Last();
        _toLookupStrong = new StronglyTypedInt(_toLookup);
        _toLookupRefStrong = new ReferenceStronglyTypedInt(_toLookup);
        _toLookupGenericStrong = new GenericStronglyTypedKey<int>(_toLookup);
        _primitive = contents.ToDictionary(x => x, x => x.ToString());
        _withStrong = contents.ToDictionary(i => new StronglyTypedInt(i), x => x.ToString());
        _withStrongWithCustomComparer =
            contents.ToDictionary(i => new StronglyTypedInt(i), x => x.ToString(),
                new StronglyTypedKeyEqualityComparerInt());
        _withRefStrong = contents.ToDictionary(i => new ReferenceStronglyTypedInt(i), x => x.ToString());
        _withRefStrongWithCustomComparer =
            contents.ToDictionary(i => new ReferenceStronglyTypedInt(i), x => x.ToString(),
                new ReferenceStronglyTypedKeyEqualityComparerInt());
        _withGenericStrong =
            contents.ToDictionary(x => new GenericStronglyTypedKey<int>(x), x => x.ToString());
        _withGenericStrongWithCustomComparer =
            contents.ToDictionary(x => new GenericStronglyTypedKey<int>(x), x => x.ToString(),
                new GenericStronglyTypedKeyEqualityComparerInt());
    }

    public string Lookup() => _primitive[_toLookup];
    public string LookupStrong() => _withStrong[_toLookupStrong];
    public string LookupWithStrongCustomComparer() => _withStrongWithCustomComparer[_toLookupStrong];
    public string LookupRefStrong() => _withRefStrong[_toLookupRefStrong];
    public string LookupRefStrongCustomComparer() => _withRefStrongWithCustomComparer[_toLookupRefStrong];
    public string LookupWithGenericStrong() => _withGenericStrong[_toLookupGenericStrong];
    public string LookupGenericStrongCustomComparer() => _withGenericStrongWithCustomComparer[_toLookupGenericStrong];
}

public class GuidImplementation : IBenchmarks
{
    private readonly Dictionary<Guid, string> _primitive;
    private readonly Guid _toLookup;
    private readonly GenericStronglyTypedKey<Guid> _toLookupGenericStrong;
    private readonly ReferenceStronglyTypedGuid _toLookupRefStrong;
    private readonly StronglyTypedGuid _toLookupStrong;
    private readonly Dictionary<GenericStronglyTypedKey<Guid>, string> _withGenericStrong;
    private readonly Dictionary<GenericStronglyTypedKey<Guid>, string> _withGenericStrongWithCustomComparer;
    private readonly Dictionary<ReferenceStronglyTypedGuid, string> _withRefStrong;
    private readonly Dictionary<ReferenceStronglyTypedGuid, string> _withRefStrongWithCustomComparer;
    private readonly Dictionary<StronglyTypedGuid, string> _withStrong;
    private readonly Dictionary<StronglyTypedGuid, string> _withStrongWithCustomComparer;

    public GuidImplementation(int n)
    {
        var contents = Enumerable.Range(0, n).Select(_ => Guid.NewGuid()).ToArray();
        _toLookup = contents.Last();
        _toLookupStrong = new StronglyTypedGuid(_toLookup);
        _toLookupRefStrong = new ReferenceStronglyTypedGuid(_toLookup);
        _toLookupGenericStrong = new GenericStronglyTypedKey<Guid>(_toLookup);
        _primitive = contents.ToDictionary(x => x, x => x.ToString());
        _withStrong = contents.ToDictionary(i => new StronglyTypedGuid(i), x => x.ToString());
        _withStrongWithCustomComparer =
            contents.ToDictionary(i => new StronglyTypedGuid(i), x => x.ToString(),
                new StronglyTypedKeyEqualityComparerGuid());
        _withRefStrong = contents.ToDictionary(i => new ReferenceStronglyTypedGuid(i), x => x.ToString());
        _withRefStrongWithCustomComparer =
            contents.ToDictionary(i => new ReferenceStronglyTypedGuid(i), x => x.ToString(),
                new ReferenceStronglyTypedKeyEqualityComparerGuid());
        _withGenericStrong =
            contents.ToDictionary(x => new GenericStronglyTypedKey<Guid>(x), x => x.ToString());
        _withGenericStrongWithCustomComparer =
            contents.ToDictionary(x => new GenericStronglyTypedKey<Guid>(x), x => x.ToString(),
                new GenericStronglyTypedKeyEqualityComparerGuid());
    }

    public string Lookup() => _primitive[_toLookup];
    public string LookupStrong() => _withStrong[_toLookupStrong];
    public string LookupWithStrongCustomComparer() => _withStrongWithCustomComparer[_toLookupStrong];
    public string LookupRefStrong() => _withRefStrong[_toLookupRefStrong];
    public string LookupRefStrongCustomComparer() => _withRefStrongWithCustomComparer[_toLookupRefStrong];
    public string LookupWithGenericStrong() => _withGenericStrong[_toLookupGenericStrong];
    public string LookupGenericStrongCustomComparer() => _withGenericStrongWithCustomComparer[_toLookupGenericStrong];
}

public class StringImplementation : IBenchmarks
{
    private readonly Dictionary<string, string> _primitive;
    private readonly string _toLookup;
    private readonly GenericStronglyTypedKey<string> _toLookupGenericStrong;
    private readonly ReferenceStronglyTypedString _toLookupRefStrong;
    private readonly StronglyTypedString _toLookupStrong;
    private readonly Dictionary<GenericStronglyTypedKey<string>, string> _withGenericStrong;
    private readonly Dictionary<GenericStronglyTypedKey<string>, string> _withGenericStrongWithCustomComparer;
    private readonly Dictionary<ReferenceStronglyTypedString, string> _withRefStrong;
    private readonly Dictionary<ReferenceStronglyTypedString, string> _withRefStrongWithCustomComparer;
    private readonly Dictionary<StronglyTypedString, string> _withStrong;
    private readonly Dictionary<StronglyTypedString, string> _withStrongWithCustomComparer;

    public StringImplementation(int n)
    {
        var contents = Enumerable.Range(0, n).Select(i => $"some-string-key-for-the-dictionary-{i}").ToArray();
        _toLookup = contents.Last();
        _toLookupStrong = new StronglyTypedString(_toLookup);
        _toLookupRefStrong = new ReferenceStronglyTypedString(_toLookup);
        _toLookupGenericStrong = new GenericStronglyTypedKey<string>(_toLookup);
        _primitive = contents.ToDictionary(x => x, x => x.ToString());
        _withStrong = contents.ToDictionary(i => new StronglyTypedString(i), x => x.ToString());
        _withStrongWithCustomComparer =
            contents.ToDictionary(i => new StronglyTypedString(i), x => x.ToString(),
                new StronglyTypedKeyEqualityComparerString());
        _withRefStrong = contents.ToDictionary(i => new ReferenceStronglyTypedString(i), x => x.ToString());
        _withRefStrongWithCustomComparer =
            contents.ToDictionary(i => new ReferenceStronglyTypedString(i), x => x.ToString(),
                new ReferenceStronglyTypedKeyEqualityComparerString());
        _withGenericStrong =
            contents.ToDictionary(x => new GenericStronglyTypedKey<string>(x), x => x.ToString());
        _withGenericStrongWithCustomComparer =
            contents.ToDictionary(x => new GenericStronglyTypedKey<string>(x), x => x.ToString(),
                new GenericStronglyTypedKeyEqualityComparerString());
    }

    public string Lookup() => _primitive[_toLookup];
    public string LookupStrong() => _withStrong[_toLookupStrong];
    public string LookupWithStrongCustomComparer() => _withStrongWithCustomComparer[_toLookupStrong];
    public string LookupRefStrong() => _withRefStrong[_toLookupRefStrong];
    public string LookupRefStrongCustomComparer() => _withRefStrongWithCustomComparer[_toLookupRefStrong];
    public string LookupWithGenericStrong() => _withGenericStrong[_toLookupGenericStrong];
    public string LookupGenericStrongCustomComparer() => _withGenericStrongWithCustomComparer[_toLookupGenericStrong];
}