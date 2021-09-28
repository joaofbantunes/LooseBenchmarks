# Generics, structs and interfaces as parameters

As I played a bit with the visitor pattern [here](https://github.com/joaofbantunes/BackToBasicsTheMessWereMakingOutOfOOP/blob/v2/src/TheMessWereMakingOutOfOOP.06.MinimizingExceptions.Web/Shared/Result.cs), in the implementation of a visitor over [here](https://github.com/joaofbantunes/BackToBasicsTheMessWereMakingOutOfOOP/blob/v2/src/TheMessWereMakingOutOfOOP.06.MinimizingExceptions.Web/Shared/ResultExtensions.cs) I remembered that for such a simple implementation, using a struct could be useful to minimize allocations. This is only true if we use the struct in tandem with generics, as if we just use the interface directly, it will box the struct.

This benchmark application illustrates the differences between these approaches.

## Results

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT


```
|                    Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Rank |  Gen 0 | Allocated |
|-------------------------- |---------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|
|  InterfaceCallerWithClass | 4.941 ns | 0.0916 ns | 0.0812 ns |  1.00 |    0.00 |    2 | 0.0038 |      24 B |
| InterfaceCallerWithStruct | 4.913 ns | 0.0451 ns | 0.0422 ns |  0.99 |    0.02 |    2 | 0.0038 |      24 B |
|    GenericCallerWithClass | 5.277 ns | 0.0623 ns | 0.0583 ns |  1.07 |    0.02 |    3 | 0.0038 |      24 B |
|   GenericCallerWithStruct | 1.407 ns | 0.0056 ns | 0.0053 ns |  0.28 |    0.00 |    1 |      - |         - |