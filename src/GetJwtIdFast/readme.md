```

BenchmarkDotNet v0.15.8, macOS Tahoe 26.5.2 (25F84) [Darwin 25.5.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 11.0.100-preview.6.26359.118
  [Host]     : .NET 10.0.10 (10.0.10, 10.0.1026.32716), Arm64 RyuJIT armv8.0-a
  DefaultJob : .NET 10.0.10 (10.0.10, 10.0.1026.32716), Arm64 RyuJIT armv8.0-a


```
| Method                  | Mean     | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------ |---------:|----------:|----------:|------:|--------:|-----:|-------:|-------:|----------:|------------:|
| NativeTokenHandler      | 2.164 μs | 0.0428 μs | 0.0641 μs |  1.00 |    0.04 |    3 | 1.3924 | 0.0305 |    8736 B |        1.00 |
| NewerNativeTokenHandler | 1.544 μs | 0.0245 μs | 0.0205 μs |  0.71 |    0.02 |    2 | 0.6027 | 0.0076 |    3792 B |        0.43 |
| Hack                    | 1.302 μs | 0.0032 μs | 0.0027 μs |  0.60 |    0.02 |    1 | 0.0153 |      - |      96 B |        0.01 |
