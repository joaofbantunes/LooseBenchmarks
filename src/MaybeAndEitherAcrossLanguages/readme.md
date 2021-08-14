# Maybe/Option, Either/Result - some functional constructs in C# vs F#

As I've been playing with functional constructs in the past in C#, wanted to take a look at how they compare to F#, which has first class support for them.

Note that I'm very much learning F# at this point, so there might be better ways to do these things, which means the benchmarks could be unfair.

## Results

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT


```
|                                  Method |         Mean |      Error |     StdDev | Ratio | RatioSD | Rank |   Gen 0 | Allocated |
|---------------------------------------- |-------------:|-----------:|-----------:|------:|--------:|-----:|--------:|----------:|
|                        MaybeChainCSharp |     44.69 ns |   0.172 ns |   0.160 ns |  1.00 |    0.00 |    2 |       - |         - |
|                        MaybeChainFSharp |     21.74 ns |   0.441 ns |   0.391 ns |  0.49 |    0.01 |    1 |  0.0191 |     120 B |
|                                         |              |            |            |       |         |      |         |           |
|             MaybeChainWithClosureCSharp |     49.19 ns |   0.362 ns |   0.339 ns |  1.00 |    0.00 |    2 |  0.0446 |     280 B |
|             MaybeChainWithClosureFSharp |     25.35 ns |   0.562 ns |   0.647 ns |  0.52 |    0.02 |    1 |  0.0344 |     216 B |
|                                         |              |            |            |       |         |      |         |           |
|                       EitherChainCSharp |     30.91 ns |   0.066 ns |   0.062 ns |  1.00 |    0.00 |    2 |  0.0191 |     120 B |
|                       EitherChainFSharp |     74.04 ns |   0.168 ns |   0.149 ns |  2.40 |    0.01 |    3 |       - |         - |
|                  ValueEitherChainCSharp |     16.79 ns |   0.052 ns |   0.049 ns |  0.54 |    0.00 |    1 |       - |         - |
|                                         |              |            |            |       |         |      |         |           |
|            EitherChainWithClosureCSharp |     50.24 ns |   0.621 ns |   0.580 ns |  1.00 |    0.00 |    2 |  0.0637 |     400 B |
|            EitherChainWithClosureFSharp |     81.64 ns |   0.321 ns |   0.285 ns |  1.63 |    0.02 |    3 |  0.0153 |      96 B |
|       ValueEitherChainWithClosureCSharp |     39.24 ns |   0.289 ns |   0.256 ns |  0.78 |    0.01 |    1 |  0.0446 |     280 B |
|                                         |              |            |            |       |         |      |         |           |
|                  MaybeChainInLoopCSharp | 22,586.88 ns |  50.397 ns |  47.141 ns |  1.00 |    0.00 |    2 |       - |         - |
|                  MaybeChainInLoopFSharp | 10,485.27 ns |  79.233 ns |  70.238 ns |  0.46 |    0.00 |    1 |  9.5520 |  60,000 B |
|                                         |              |            |            |       |         |      |         |           |
|       MaybeChainWithClosureInLoopCSharp | 24,976.42 ns | 106.455 ns |  88.894 ns |  1.00 |    0.00 |    2 | 22.3083 | 140,000 B |
|       MaybeChainWithClosureInLoopFSharp | 13,155.74 ns | 107.988 ns | 101.012 ns |  0.53 |    0.00 |    1 | 17.2119 | 108,000 B |
|                                         |              |            |            |       |         |      |         |           |
|                 EitherChainInLoopCSharp | 15,559.75 ns | 100.617 ns |  94.117 ns |  1.00 |    0.00 |    2 |  9.5520 |  60,000 B |
|                 EitherChainInLoopFSharp | 36,367.54 ns | 270.000 ns | 239.348 ns |  2.34 |    0.02 |    3 |       - |         - |
|            ValueEitherChainInLoopCSharp |  8,885.05 ns |  71.290 ns |  66.684 ns |  0.57 |    0.01 |    1 |       - |         - |
|                                         |              |            |            |       |         |      |         |           |
|      EitherChainWithClosureInLoopCSharp | 25,121.52 ns | 160.742 ns | 142.494 ns |  1.00 |    0.00 |    2 | 31.8604 | 200,000 B |
|      EitherChainWithClosureInLoopFSharp | 41,013.03 ns | 161.031 ns | 142.750 ns |  1.63 |    0.01 |    3 |  7.6294 |  48,000 B |
| ValueEitherChainWithClosureInLoopCSharp | 20,019.25 ns | 219.891 ns | 253.227 ns |  0.80 |    0.01 |    1 | 22.3083 | 140,000 B |
