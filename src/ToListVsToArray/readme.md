``` ini

BenchmarkDotNet=v0.13.1, OS=macOS 13.4 (22F66) [Darwin 22.5.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=8.0.100-preview.4.23260.5
  [Host]     : .NET 6.0.16 (6.0.1623.17311), Arm64 RyuJIT
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), Arm64 RyuJIT


```
|  Method |      N |          Mean |      Error |     StdDev | Ratio | Rank |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|-------- |------- |--------------:|-----------:|-----------:|------:|-----:|---------:|---------:|---------:|----------:|
|  **ToList** |      **1** |      **43.23 ns** |   **0.138 ns** |   **0.122 ns** |  **1.00** |    **2** |   **0.0497** |        **-** |        **-** |     **104 B** |
| ToArray |      1 |      34.86 ns |   0.379 ns |   0.317 ns |  0.81 |    1 |   0.0344 |        - |        - |      72 B |
|         |        |               |            |            |       |      |          |          |          |           |
|  **ToList** |     **10** |      **55.53 ns** |   **0.491 ns** |   **0.383 ns** |  **1.00** |    **2** |   **0.0650** |        **-** |        **-** |     **136 B** |
| ToArray |     10 |      43.09 ns |   0.254 ns |   0.226 ns |  0.78 |    1 |   0.0497 |        - |        - |     104 B |
|         |        |               |            |            |       |      |          |          |          |           |
|  **ToList** |    **100** |     **170.93 ns** |   **1.854 ns** |   **1.734 ns** |  **1.00** |    **2** |   **0.2370** |        **-** |        **-** |     **496 B** |
| ToArray |    100 |     106.28 ns |   0.622 ns |   0.520 ns |  0.62 |    1 |   0.2218 |        - |        - |     464 B |
|         |        |               |            |            |       |      |          |          |          |           |
|  **ToList** |   **1000** |   **1,236.11 ns** |   **8.546 ns** |   **7.994 ns** |  **1.00** |    **2** |   **1.9569** |        **-** |        **-** |   **4,096 B** |
| ToArray |   1000 |     787.61 ns |   8.144 ns |   7.219 ns |  0.64 |    1 |   1.9417 |        - |        - |   4,064 B |
|         |        |               |            |            |       |      |          |          |          |           |
|  **ToList** |  **10000** |  **11,526.01 ns** | **109.072 ns** | **102.026 ns** |  **1.00** |    **2** |  **18.8599** |        **-** |        **-** |  **40,096 B** |
| ToArray |  10000 |   7,482.69 ns |  93.024 ns |  82.463 ns |  0.65 |    1 |  18.8599 |        - |        - |  40,064 B |
|         |        |               |            |            |       |      |          |          |          |           |
|  **ToList** | **100000** | **112,707.23 ns** | **829.626 ns** | **776.033 ns** |  **1.00** |    **2** | **124.8779** | **124.8779** | **124.8779** | **400,180 B** |
| ToArray | 100000 |  73,720.65 ns | 685.765 ns | 641.465 ns |  0.65 |    1 | 124.8779 | 124.8779 | 124.8779 | 400,148 B |