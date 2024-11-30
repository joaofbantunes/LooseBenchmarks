using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

DoSanityCheck();

_ = BenchmarkRunner.Run<Benchmark>();

static void DoSanityCheck()
{
    var benchmark = new Benchmark
    {
        N = 10
    };
    benchmark.GlobalSetup();
    var directCheckResult = benchmark.DirectCheck();
    var toHashSetAndCheckResult = benchmark.ToHashSetAndCheck();
    if (!directCheckResult || !toHashSetAndCheckResult)
    {
        throw new Exception("Sanity check failed");
    }
}

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    [Params(1, 10, 25, 50, 100, 1_000, 10_000)]
    public int N;

    private List<Item> _items = null!;
    private IReadOnlyCollection<Item> _itemsToCheck = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _items = Enumerable.Range(0, N)
            .Select(i => new Item { Id = Guid.NewGuid().ToString(), Value = $"Some value {i}" })
            .ToList();
        _itemsToCheck = _items.ToList();
    }

    [Benchmark(Baseline = true)]
    public bool DirectCheck()
    {
        foreach (var item in _items)
        {
            if (_itemsToCheck.All(i => i.Id != item.Id))
            {
                return false;
            }
        }

        return true;
    }

    [Benchmark]
    public bool ToHashSetAndCheck()
    {
        var itemsToCheckSet = new HashSet<string>(_itemsToCheck.Select(i => i.Id));
        foreach (var item in _items)
        {
            if (!itemsToCheckSet.Contains(item.Id))
            {
                return false;
            }
        }

        return true;
    }
}

public class Item
{
    public required string Id { get; init; }
    public required string Value { get; init; }
}