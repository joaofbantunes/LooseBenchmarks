```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.100-preview.3.24204.13
  [Host]     : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD


```
| Method                                | N     | Mean      | Error     | StdDev    | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|-------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|-----:|----------:|------------:|
| **LookupTraditional**                     | **10**    |  **7.631 ns** | **0.0525 ns** | **0.0466 ns** |  **1.00** |    **0.00** |    **2** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKey | 10    | 10.470 ns | 0.1367 ns | 0.1279 ns |  1.37 |    0.02 |    3 |         - |          NA |
| LookupFrozen                          | 10    |  3.037 ns | 0.0484 ns | 0.0453 ns |  0.40 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKey      | 10    | 26.205 ns | 0.0848 ns | 0.0793 ns |  3.43 |    0.02 |    4 |         - |          NA |
|                                       |       |           |           |           |       |         |      |           |             |
| **LookupTraditional**                     | **100**   |  **7.499 ns** | **0.0559 ns** | **0.0496 ns** |  **1.00** |    **0.00** |    **2** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKey | 100   | 11.813 ns | 0.0559 ns | 0.0495 ns |  1.58 |    0.01 |    3 |         - |          NA |
| LookupFrozen                          | 100   |  4.225 ns | 0.0335 ns | 0.0297 ns |  0.56 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKey      | 100   | 11.718 ns | 0.0471 ns | 0.0440 ns |  1.56 |    0.01 |    3 |         - |          NA |
|                                       |       |           |           |           |       |         |      |           |             |
| **LookupTraditional**                     | **1000**  |  **7.758 ns** | **0.0425 ns** | **0.0397 ns** |  **1.00** |    **0.00** |    **2** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKey | 1000  | 11.852 ns | 0.0356 ns | 0.0333 ns |  1.53 |    0.01 |    4 |         - |          NA |
| LookupFrozen                          | 1000  |  4.827 ns | 0.0236 ns | 0.0209 ns |  0.62 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKey      | 1000  | 11.677 ns | 0.0553 ns | 0.0462 ns |  1.51 |    0.01 |    3 |         - |          NA |
|                                       |       |           |           |           |       |         |      |           |             |
| **LookupTraditional**                     | **10000** |  **7.760 ns** | **0.0452 ns** | **0.0423 ns** |  **1.00** |    **0.00** |    **2** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKey | 10000 | 12.861 ns | 0.0443 ns | 0.0346 ns |  1.66 |    0.01 |    3 |         - |          NA |
| LookupFrozen                          | 10000 |  4.366 ns | 0.0160 ns | 0.0149 ns |  0.56 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKey      | 10000 | 12.753 ns | 0.0699 ns | 0.0653 ns |  1.64 |    0.01 |    3 |         - |          NA |
