```

BenchmarkDotNet v0.13.12, macOS 15.0.1 (24A348) [Darwin 24.0.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.10 (8.0.1024.46610), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), Arm64 RyuJIT AdvSIMD


```
| Method                     | N      | Mean             | Error          | StdDev         | Ratio | Rank | Gen0      | Gen1      | Gen2     | Allocated  | Alloc Ratio |
|--------------------------- |------- |-----------------:|---------------:|---------------:|------:|-----:|----------:|----------:|---------:|-----------:|------------:|
| **JsonNotSourceGenerated**     | **1**      |        **174.01 ns** |       **1.708 ns** |       **1.514 ns** |  **1.00** |    **3** |    **0.0663** |         **-** |        **-** |      **416 B** |        **1.00** |
| JsonSourceGenerated        | 1      |         95.72 ns |       0.347 ns |       0.271 ns |  0.55 |    2 |    0.0114 |         - |        - |       72 B |        0.17 |
| ProtobufNotSourceGenerated | 1      |         70.92 ns |       0.749 ns |       0.664 ns |  0.41 |    1 |    0.0191 |         - |        - |      120 B |        0.29 |
|                            |        |                  |                |                |       |      |           |           |          |            |             |
| **JsonNotSourceGenerated**     | **10**     |      **1,013.28 ns** |       **9.331 ns** |       **7.285 ns** |  **1.00** |    **3** |    **0.1755** |         **-** |        **-** |     **1104 B** |        **1.00** |
| JsonSourceGenerated        | 10     |        552.80 ns |       1.684 ns |       1.406 ns |  0.55 |    2 |    0.0744 |         - |        - |      472 B |        0.43 |
| ProtobufNotSourceGenerated | 10     |        462.78 ns |       1.704 ns |       1.423 ns |  0.46 |    1 |    0.0587 |         - |        - |      368 B |        0.33 |
|                            |        |                  |                |                |       |      |           |           |          |            |             |
| **JsonNotSourceGenerated**     | **100**    |      **9,514.69 ns** |      **30.785 ns** |      **27.290 ns** |  **1.00** |    **3** |    **1.2817** |         **-** |        **-** |     **8120 B** |        **1.00** |
| JsonSourceGenerated        | 100    |      4,959.83 ns |      15.415 ns |      13.665 ns |  0.52 |    2 |    0.7324 |         - |        - |     4608 B |        0.57 |
| ProtobufNotSourceGenerated | 100    |      4,307.48 ns |      18.534 ns |      15.477 ns |  0.45 |    1 |    0.4883 |         - |        - |     3072 B |        0.38 |
|                            |        |                  |                |                |       |      |           |           |          |            |             |
| **JsonNotSourceGenerated**     | **1000**   |     **97,654.39 ns** |   **1,026.516 ns** |     **960.204 ns** |  **1.00** |    **3** |   **12.5732** |         **-** |        **-** |    **80134 B** |        **1.00** |
| JsonSourceGenerated        | 1000   |     50,945.08 ns |     165.185 ns |     137.937 ns |  0.52 |    2 |    7.5684 |         - |        - |    47815 B |        0.60 |
| ProtobufNotSourceGenerated | 1000   |     43,160.98 ns |     470.028 ns |     392.495 ns |  0.44 |    1 |    5.0049 |         - |        - |    31872 B |        0.40 |
|                            |        |                  |                |                |       |      |           |           |          |            |             |
| **JsonNotSourceGenerated**     | **10000**  |  **1,154,539.39 ns** |   **6,068.166 ns** |   **5,676.166 ns** |  **1.00** |    **3** |  **226.5625** |  **191.4063** | **164.0625** |   **965224 B** |        **1.00** |
| JsonSourceGenerated        | 10000  |    605,703.62 ns |   2,115.833 ns |   1,875.631 ns |  0.52 |    2 |  153.3203 |  151.3672 | 146.4844 |   608785 B |        0.63 |
| ProtobufNotSourceGenerated | 10000  |    515,032.42 ns |   2,734.874 ns |   2,424.395 ns |  0.45 |    1 |  266.6016 |  266.6016 |  76.1719 |   338233 B |        0.35 |
|                            |        |                  |                |                |       |      |           |           |          |            |             |
| **JsonNotSourceGenerated**     | **100000** | **13,016,470.10 ns** | **200,248.297 ns** | **187,312.381 ns** |  **1.00** |    **3** | **1406.2500** |  **984.3750** | **859.3750** | **21215992 B** |        **1.00** |
| JsonSourceGenerated        | 100000 |  8,321,262.58 ns |  66,691.985 ns |  62,383.724 ns |  0.64 |    2 | 1000.0000 | 1000.0000 | 921.8750 | 19251027 B |        0.91 |
| ProtobufNotSourceGenerated | 100000 |  4,859,184.36 ns |  21,060.790 ns |  17,586.714 ns |  0.37 |    1 |  226.5625 |  226.5625 | 187.5000 |  3579400 B |        0.17 |