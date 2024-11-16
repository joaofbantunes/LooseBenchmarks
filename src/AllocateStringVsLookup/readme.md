```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.1 (24B83) [Darwin 24.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


```
| Method                       | N    | Mean      | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |----- |----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
| **IfWeAlreadyHadTheKey**         | **1**    |  **5.345 ns** | **0.1043 ns** | **0.0871 ns** |  **1.00** |    **0.02** |    **2** |      **-** |         **-** |          **NA** |
| AllocateAndLookup            | 1    | 14.110 ns | 0.1117 ns | 0.1045 ns |  2.64 |    0.05 |    4 | 0.0127 |      80 B |          NA |
| TupleAndLookup               | 1    |  1.881 ns | 0.0298 ns | 0.0279 ns |  0.35 |    0.01 |    1 |      - |         - |          NA |
| DoubleLookup                 | 1    |  6.643 ns | 0.0759 ns | 0.0634 ns |  1.24 |    0.02 |    3 |      - |         - |          NA |
| SpanConcatAndAlternateLookup | 1    | 13.743 ns | 0.0588 ns | 0.0521 ns |  2.57 |    0.04 |    4 |      - |         - |          NA |
|                              |      |           |           |           |       |         |      |        |           |             |
| **IfWeAlreadyHadTheKey**         | **10**   | **11.196 ns** | **0.0225 ns** | **0.0176 ns** |  **1.00** |    **0.00** |    **2** |      **-** |         **-** |          **NA** |
| AllocateAndLookup            | 10   | 20.539 ns | 0.4463 ns | 0.4775 ns |  1.83 |    0.04 |    3 | 0.0127 |      80 B |          NA |
| TupleAndLookup               | 10   | 28.111 ns | 0.2169 ns | 0.1923 ns |  2.51 |    0.02 |    4 |      - |         - |          NA |
| DoubleLookup                 | 10   |  8.881 ns | 0.0859 ns | 0.0803 ns |  0.79 |    0.01 |    1 |      - |         - |          NA |
| SpanConcatAndAlternateLookup | 10   | 20.008 ns | 0.0499 ns | 0.0442 ns |  1.79 |    0.00 |    3 |      - |         - |          NA |
|                              |      |           |           |           |       |         |      |        |           |             |
| **IfWeAlreadyHadTheKey**         | **100**  | **11.598 ns** | **0.0380 ns** | **0.0337 ns** |  **1.00** |    **0.00** |    **1** |      **-** |         **-** |          **NA** |
| AllocateAndLookup            | 100  | 20.126 ns | 0.2664 ns | 0.2492 ns |  1.74 |    0.02 |    3 | 0.0127 |      80 B |          NA |
| TupleAndLookup               | 100  | 27.697 ns | 0.1101 ns | 0.0919 ns |  2.39 |    0.01 |    4 |      - |         - |          NA |
| DoubleLookup                 | 100  | 12.036 ns | 0.0195 ns | 0.0163 ns |  1.04 |    0.00 |    2 |      - |         - |          NA |
| SpanConcatAndAlternateLookup | 100  | 19.975 ns | 0.1230 ns | 0.1090 ns |  1.72 |    0.01 |    3 |      - |         - |          NA |
|                              |      |           |           |           |       |         |      |        |           |             |
| **IfWeAlreadyHadTheKey**         | **1000** | **11.054 ns** | **0.0449 ns** | **0.0398 ns** |  **1.00** |    **0.00** |    **1** |      **-** |         **-** |          **NA** |
| AllocateAndLookup            | 1000 | 20.671 ns | 0.4421 ns | 0.5902 ns |  1.87 |    0.05 |    3 | 0.0127 |      80 B |          NA |
| TupleAndLookup               | 1000 | 28.609 ns | 0.1113 ns | 0.0987 ns |  2.59 |    0.01 |    4 |      - |         - |          NA |
| DoubleLookup                 | 1000 | 13.759 ns | 0.1494 ns | 0.1398 ns |  1.24 |    0.01 |    2 |      - |         - |          NA |
| SpanConcatAndAlternateLookup | 1000 | 19.984 ns | 0.0696 ns | 0.0651 ns |  1.81 |    0.01 |    3 |      - |         - |          NA |
