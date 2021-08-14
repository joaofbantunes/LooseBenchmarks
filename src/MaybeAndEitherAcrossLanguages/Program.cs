using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using MaybeAndEitherAcrossLanguages.CSharp;
using Microsoft.FSharp.Core;

Benchmark.DoSanityChecks();
var summary = BenchmarkRunner.Run<Benchmark>();

[RankColumn]
[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{

    [Benchmark(Baseline = true), BenchmarkCategory("MaybeChain")]
    public Maybe<int> MaybeChainCSharp()
        => MaybeAndEitherAcrossLanguages.CSharp.Scenarios.MaybeChain(1);

    [Benchmark, BenchmarkCategory("MaybeChain")]
    public FSharpOption<int> MaybeChainFSharp()
        => MaybeAndEitherAcrossLanguages.FSharp.Scenarios.maybeChain(1);

    [Benchmark(Baseline = true), BenchmarkCategory("MaybeChainWithClosure")]
    public Maybe<int> MaybeChainWithClosureCSharp()
        => MaybeAndEitherAcrossLanguages.CSharp.Scenarios.MaybeChainnWithClosure(1, 1);

    [Benchmark, BenchmarkCategory("MaybeChainWithClosure")]
    public FSharpOption<int> MaybeChainWithClosureFSharp()
        => MaybeAndEitherAcrossLanguages.FSharp.Scenarios.maybeChainWithClosure(1, 1);

    [Benchmark(Baseline = true), BenchmarkCategory("EitherChain")]
    public Either<string, int> EitherChainCSharp()
       => MaybeAndEitherAcrossLanguages.CSharp.Scenarios.EitherChain(1);

    [Benchmark, BenchmarkCategory("EitherChain")]
    public FSharpResult<int, string> EitherChainFSharp()
        => MaybeAndEitherAcrossLanguages.FSharp.Scenarios.eitherChain(1);

    [Benchmark, BenchmarkCategory("EitherChain")]
    public ValueEither<string, int> ValueEitherChainCSharp()
        => MaybeAndEitherAcrossLanguages.CSharp.Scenarios.ValueEitherChain(1);

    [Benchmark(Baseline = true), BenchmarkCategory("EitherChainWithClosure")]
    public Either<string, int> EitherChainWithClosureCSharp()
        => MaybeAndEitherAcrossLanguages.CSharp.Scenarios.EitherChainWithClosure(1, 1);

    [Benchmark, BenchmarkCategory("EitherChainWithClosure")]
    public FSharpResult<int, string> EitherChainWithClosureFSharp()
        => MaybeAndEitherAcrossLanguages.FSharp.Scenarios.eitherChainWithClosure(1, 1);

    [Benchmark, BenchmarkCategory("EitherChainWithClosure")]
    public ValueEither<string, int> ValueEitherChainWithClosureCSharp()
        => MaybeAndEitherAcrossLanguages.CSharp.Scenarios.ValueEitherChainWithClosure(1, 1);



    private const int Iterations = 500;

    [Benchmark(Baseline = true), BenchmarkCategory("MaybeChainInLoop")]
    public Maybe<int> MaybeChainInLoopCSharp()
    {
        Maybe<int> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.CSharp.Scenarios.MaybeChain(1);
        }
        return result;
    }

    [Benchmark, BenchmarkCategory("MaybeChainInLoop")]
    public FSharpOption<int> MaybeChainInLoopFSharp()
    {
        FSharpOption<int> result = FSharpOption<int>.None;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.FSharp.Scenarios.maybeChain(1);
        }
        return result;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("MaybeChainWithClosureInLoop")]
    public Maybe<int> MaybeChainWithClosureInLoopCSharp()
    {
        Maybe<int> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.CSharp.Scenarios.MaybeChainnWithClosure(1, 1);
        }
        return result;
    }

    [Benchmark, BenchmarkCategory("MaybeChainWithClosureInLoop")]
    public FSharpOption<int> MaybeChainWithClosureInLoopFSharp()
    {
        FSharpOption<int> result = FSharpOption<int>.None;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.FSharp.Scenarios.maybeChainWithClosure(1, 1);
        }
        return result;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("EitherChainInLoop")]
    public Either<string, int> EitherChainInLoopCSharp()
    {
        Either<string, int> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.CSharp.Scenarios.EitherChain(1);
        }
        return result;

    }

    [Benchmark, BenchmarkCategory("EitherChainInLoop")]
    public FSharpResult<int, string> EitherChainInLoopFSharp()
    {
        FSharpResult<int, string> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.FSharp.Scenarios.eitherChain(1);
        }
        return result;
    }

    [Benchmark, BenchmarkCategory("EitherChainInLoop")]
    public ValueEither<string, int> ValueEitherChainInLoopCSharp()
    {
        ValueEither<string, int> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.CSharp.Scenarios.ValueEitherChain(1);
        }
        return result;

    }

    [Benchmark(Baseline = true), BenchmarkCategory("EitherChainWithClosureInLoop")]
    public Either<string, int> EitherChainWithClosureInLoopCSharp()
    {
        Either<string, int> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.CSharp.Scenarios.EitherChainWithClosure(1, 1);
        }
        return result;
    }

    [Benchmark, BenchmarkCategory("EitherChainWithClosureInLoop")]
    public FSharpResult<int, string> EitherChainWithClosureInLoopFSharp()
    {
        FSharpResult<int, string> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.FSharp.Scenarios.eitherChainWithClosure(1, 1);
        }
        return result;
    }

    [Benchmark, BenchmarkCategory("EitherChainWithClosureInLoop")]
    public ValueEither<string, int> ValueEitherChainWithClosureInLoopCSharp()
    {
        ValueEither<string, int> result = default;
        for (var i = 0; i < Iterations; ++i)
        {
            result = MaybeAndEitherAcrossLanguages.CSharp.Scenarios.ValueEitherChainWithClosure(1, 1);
        }
        return result;
    }


    public static void DoSanityChecks()
    {
        Console.WriteLine("Doing sanity checks");

        var benchmark = new Benchmark();

        benchmark.MaybeChainCSharp().MatchSome(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.MaybeChainFSharp().Value != 5) throw new Exception();

        benchmark.MaybeChainWithClosureCSharp().MatchSome(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.MaybeChainWithClosureFSharp().Value != 5) throw new Exception();

        benchmark.EitherChainCSharp().Do(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.EitherChainFSharp().ResultValue != 5) throw new Exception();

        benchmark.EitherChainCSharp().Do(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.EitherChainFSharp().ResultValue != 5) throw new Exception();
        benchmark.ValueEitherChainCSharp().Do(value => _ = value == 5 ? true : throw new Exception());

        benchmark.EitherChainWithClosureCSharp().Do(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.EitherChainWithClosureFSharp().ResultValue != 5) throw new Exception();
        benchmark.ValueEitherChainWithClosureCSharp().Do(value => _ = value == 5 ? true : throw new Exception());


        benchmark.MaybeChainInLoopCSharp().MatchSome(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.MaybeChainInLoopFSharp().Value != 5) throw new Exception();

        benchmark.MaybeChainWithClosureInLoopCSharp().MatchSome(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.MaybeChainWithClosureInLoopFSharp().Value != 5) throw new Exception();

        benchmark.EitherChainInLoopCSharp().Do(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.EitherChainInLoopFSharp().ResultValue != 5) throw new Exception();

        benchmark.EitherChainInLoopCSharp().Do(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.EitherChainInLoopFSharp().ResultValue != 5) throw new Exception();
        benchmark.ValueEitherChainInLoopCSharp().Do(value => _ = value == 5 ? true : throw new Exception());

        benchmark.EitherChainWithClosureInLoopCSharp().Do(value => _ = value == 5 ? true : throw new Exception());
        if (benchmark.EitherChainWithClosureInLoopFSharp().ResultValue != 5) throw new Exception();
        benchmark.ValueEitherChainWithClosureInLoopCSharp().Do(value => _ = value == 5 ? true : throw new Exception());

        Console.WriteLine("Everything looking good 👍");
    }
}

