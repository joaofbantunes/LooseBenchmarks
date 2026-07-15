```

BenchmarkDotNet v0.15.8, macOS Tahoe 26.5.2 (25F84) [Darwin 25.5.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 11.0.100-preview.6.26359.118
  [Host]     : .NET 10.0.10 (10.0.10, 10.0.1026.32716), Arm64 RyuJIT armv8.0-a
  DefaultJob : .NET 10.0.10 (10.0.10, 10.0.1026.32716), Arm64 RyuJIT armv8.0-a


```
| Method                       | Mean       | Error    | StdDev   | Ratio | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |-----------:|---------:|---------:|------:|-----:|-------:|-------:|----------:|------------:|
| NativeTokenHandler           | 2,093.1 ns |  9.87 ns |  8.75 ns |  1.00 |    4 | 1.3924 | 0.0305 |    8736 B |        1.00 |
| NewerNativeTokenHandler      | 1,561.3 ns | 22.07 ns | 19.57 ns |  0.75 |    3 | 0.6027 | 0.0076 |    3792 B |        0.43 |
| Hash                         |   904.2 ns | 17.85 ns | 28.83 ns |  0.43 |    2 | 0.5569 | 0.0010 |    3496 B |        0.40 |
| SomeAllocationRemovalHash    |   870.2 ns |  4.66 ns |  4.36 ns |  0.42 |    2 | 0.5474 | 0.0038 |    3440 B |        0.39 |
| FurtherAllocationRemovalHash |   725.4 ns |  5.70 ns |  5.06 ns |  0.35 |    1 | 0.0172 |      - |     112 B |        0.01 |
