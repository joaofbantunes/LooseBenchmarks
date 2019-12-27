# Generics, structs and interfaces as parameters

As I played a bit with the visitor pattern [here](https://github.com/joaofbantunes/BackToBasicsTheMessWereMakingOutOfOOP/blob/v2/src/TheMessWereMakingOutOfOOP.06.MinimizingExceptions.Web/Shared/Result.cs), in the implementation of a visitor over [here](https://github.com/joaofbantunes/BackToBasicsTheMessWereMakingOutOfOOP/blob/v2/src/TheMessWereMakingOutOfOOP.06.MinimizingExceptions.Web/Shared/ResultExtensions.cs) I remembered that for such a simple implementation, using a struct could be useful to minimize allocations. This is only true if we use the struct in tandem with generics, as if we just use the interface directly, it will box the struct.

This benchmark application illustrates the differences between these approaches.

## Results

``` ini
BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=3.1.100
  [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  DefaultJob : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
```
|                    Method |     Mean |     Error |    StdDev | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |---------:|----------:|----------:|------:|-----:|-------:|------:|------:|----------:|
|  InterfaceCallerWithClass | 6.902 ns | 0.0536 ns | 0.0502 ns |  1.00 |    2 | 0.0038 |     - |     - |      24 B |
| InterfaceCallerWithStruct | 7.515 ns | 0.0371 ns | 0.0347 ns |  1.09 |    4 | 0.0038 |     - |     - |      24 B |
|    GenericCallerWithClass | 7.235 ns | 0.0740 ns | 0.0693 ns |  1.05 |    3 | 0.0038 |     - |     - |      24 B |
|   GenericCallerWithStruct | 3.540 ns | 0.0094 ns | 0.0083 ns |  0.51 |    1 |      - |     - |     - |         - |