using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class Benchmark
{
    [Params(10, 100, 1_000, 10_000)]
    public int N;

    private string Input { get; set; } = null!;

    private string ToSearch { get; set; } = null!;
    
    private Func<string, bool> Predicate { get; set; } = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var contents = Enumerable.Range(0, N).Select(i => $"some-number-{i}").ToArray();
        Input = string.Join(' ', contents);
        ToSearch = contents.Last();
        Predicate = x => x == ToSearch;
    }
    
    [Benchmark]
    public bool SplitPlusAny()
    {
        return Input.Split(' ').Any(x => x == ToSearch);
    }
    
    [Benchmark]
    public bool SplitPlusAnyWithPreparedPredicate()
    {
        // difference between this and SplitPlusAny is that avoiding the lambda with closure every time
        return Input.Split(' ').Any(Predicate);
    }
    
    [Benchmark]
    public bool SplitPlusLoop()
    {
        foreach (var x in Input.Split(' '))
        {
            if (x == ToSearch)
            {
                return true;
            }
        }
        return false;
    }
    
    [Benchmark]
    public bool SpanCheckingWord()
    {
        var span = Input.AsSpan();
        while (true)
        {
            var index = span.IndexOf(' ');
            if (index == -1)
            {
                return span.Equals(ToSearch, StringComparison.Ordinal);
            }
            if (span[..index].Equals(ToSearch, StringComparison.Ordinal))
            {
                return true;
            }
            span = span[(index + 1)..];
        }
    }
}