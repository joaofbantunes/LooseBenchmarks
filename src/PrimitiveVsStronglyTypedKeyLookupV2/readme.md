```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.1 (24B83) [Darwin 24.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


```
| Method                                                    | N     | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
| **LookupGuid**                                                | **1**     |  **3.078 ns** | **0.0090 ns** | **0.0075 ns** |  **3.076 ns** |  **1.00** |    **0.00** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 1     |  3.586 ns | 0.0083 ns | 0.0070 ns |  3.584 ns |  1.17 |    0.00 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 1     |  4.235 ns | 0.0071 ns | 0.0060 ns |  4.236 ns |  1.38 |    0.00 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 1     |  9.727 ns | 0.0123 ns | 0.0109 ns |  9.724 ns |  3.16 |    0.01 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 1     | 40.312 ns | 0.2235 ns | 0.2091 ns | 40.229 ns | 13.10 |    0.07 |    6 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 1     |  3.568 ns | 0.0393 ns | 0.0349 ns |  3.564 ns |  1.16 |    0.01 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 1     |  4.568 ns | 0.0394 ns | 0.0307 ns |  4.559 ns |  1.48 |    0.01 |    4 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 1     |  2.560 ns | 0.0072 ns | 0.0056 ns |  2.560 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 1     |  2.387 ns | 0.0180 ns | 0.0151 ns |  2.391 ns |  0.93 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 1     |  3.499 ns | 0.0234 ns | 0.0196 ns |  3.490 ns |  1.37 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 1     |  9.113 ns | 0.1543 ns | 0.1289 ns |  9.057 ns |  3.56 |    0.05 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 1     | 32.757 ns | 0.1216 ns | 0.1078 ns | 32.721 ns | 12.79 |    0.05 |    5 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 1     |  2.467 ns | 0.0387 ns | 0.0343 ns |  2.455 ns |  0.96 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 1     |  3.334 ns | 0.0144 ns | 0.0120 ns |  3.330 ns |  1.30 |    0.01 |    2 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupString                                              | 1     | 11.478 ns | 0.0549 ns | 0.0428 ns | 11.476 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 1     | 26.328 ns | 0.0341 ns | 0.0319 ns | 26.335 ns |  2.29 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 1     | 27.104 ns | 0.1177 ns | 0.0983 ns | 27.083 ns |  2.36 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 1     | 32.605 ns | 0.1075 ns | 0.0953 ns | 32.622 ns |  2.84 |    0.01 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 1     | 30.638 ns | 0.6132 ns | 0.5121 ns | 30.423 ns |  2.67 |    0.04 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 1     | 31.622 ns | 0.0574 ns | 0.0480 ns | 31.624 ns |  2.76 |    0.01 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 1     | 30.216 ns | 0.0594 ns | 0.0527 ns | 30.205 ns |  2.63 |    0.01 |    4 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **10**    |  **3.068 ns** | **0.0604 ns** | **0.0505 ns** |  **3.055 ns** |  **1.00** |    **0.02** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 10    |  3.614 ns | 0.0384 ns | 0.0321 ns |  3.598 ns |  1.18 |    0.02 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 10    |  4.405 ns | 0.0598 ns | 0.0499 ns |  4.400 ns |  1.44 |    0.03 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 10    |  9.675 ns | 0.0955 ns | 0.0847 ns |  9.638 ns |  3.15 |    0.06 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 10    | 37.865 ns | 0.0516 ns | 0.0483 ns | 37.874 ns | 12.35 |    0.19 |    6 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 10    |  3.665 ns | 0.0826 ns | 0.0690 ns |  3.666 ns |  1.19 |    0.03 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 10    |  4.265 ns | 0.0107 ns | 0.0100 ns |  4.265 ns |  1.39 |    0.02 |    3 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 10    |  2.523 ns | 0.0151 ns | 0.0126 ns |  2.518 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 10    |  2.500 ns | 0.0136 ns | 0.0127 ns |  2.503 ns |  0.99 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 10    |  3.479 ns | 0.0144 ns | 0.0128 ns |  3.477 ns |  1.38 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 10    |  8.900 ns | 0.0753 ns | 0.0667 ns |  8.884 ns |  3.53 |    0.03 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 10    | 33.030 ns | 0.5169 ns | 0.5746 ns | 32.893 ns | 13.09 |    0.23 |    5 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 10    |  2.454 ns | 0.0073 ns | 0.0061 ns |  2.455 ns |  0.97 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 10    |  3.344 ns | 0.0212 ns | 0.0165 ns |  3.340 ns |  1.33 |    0.01 |    2 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupString                                              | 10    | 11.702 ns | 0.0279 ns | 0.0261 ns | 11.701 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 10    | 26.957 ns | 0.1221 ns | 0.1082 ns | 26.972 ns |  2.30 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 10    | 27.709 ns | 0.0797 ns | 0.0745 ns | 27.730 ns |  2.37 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 10    | 33.189 ns | 0.0876 ns | 0.0820 ns | 33.195 ns |  2.84 |    0.01 |    6 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 10    | 30.026 ns | 0.0825 ns | 0.0731 ns | 30.030 ns |  2.57 |    0.01 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 10    | 31.495 ns | 0.0871 ns | 0.0772 ns | 31.491 ns |  2.69 |    0.01 |    5 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 10    | 30.267 ns | 0.0860 ns | 0.0762 ns | 30.246 ns |  2.59 |    0.01 |    4 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **100**   |  **3.073 ns** | **0.0990 ns** | **0.0827 ns** |  **3.040 ns** |  **1.00** |    **0.04** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 100   |  3.698 ns | 0.0436 ns | 0.0341 ns |  3.689 ns |  1.20 |    0.03 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 100   |  4.409 ns | 0.0229 ns | 0.0179 ns |  4.408 ns |  1.44 |    0.04 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 100   |  9.578 ns | 0.0289 ns | 0.0241 ns |  9.569 ns |  3.12 |    0.08 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 100   | 37.713 ns | 0.0950 ns | 0.0793 ns | 37.735 ns | 12.28 |    0.30 |    5 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 100   |  3.644 ns | 0.0178 ns | 0.0149 ns |  3.640 ns |  1.19 |    0.03 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 100   |  4.351 ns | 0.0164 ns | 0.0146 ns |  4.352 ns |  1.42 |    0.04 |    3 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 100   |  2.522 ns | 0.0110 ns | 0.0097 ns |  2.523 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 100   |  2.641 ns | 0.0953 ns | 0.0936 ns |  2.617 ns |  1.05 |    0.04 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 100   |  3.506 ns | 0.1102 ns | 0.1179 ns |  3.465 ns |  1.39 |    0.05 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 100   |  8.828 ns | 0.0218 ns | 0.0171 ns |  8.828 ns |  3.50 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 100   | 32.680 ns | 0.2035 ns | 0.1589 ns | 32.625 ns | 12.96 |    0.08 |    4 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 100   |  2.566 ns | 0.0180 ns | 0.0160 ns |  2.570 ns |  1.02 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 100   |  3.337 ns | 0.0416 ns | 0.0369 ns |  3.341 ns |  1.32 |    0.01 |    2 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupString                                              | 100   | 12.888 ns | 0.0447 ns | 0.0418 ns | 12.887 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 100   | 26.871 ns | 0.0367 ns | 0.0307 ns | 26.866 ns |  2.09 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 100   | 27.386 ns | 0.0673 ns | 0.0525 ns | 27.365 ns |  2.12 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 100   | 33.320 ns | 0.0974 ns | 0.0911 ns | 33.311 ns |  2.59 |    0.01 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 100   | 29.941 ns | 0.1174 ns | 0.1098 ns | 29.950 ns |  2.32 |    0.01 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 100   | 31.653 ns | 0.0810 ns | 0.0758 ns | 31.631 ns |  2.46 |    0.01 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 100   | 30.165 ns | 0.0630 ns | 0.0558 ns | 30.161 ns |  2.34 |    0.01 |    3 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **1000**  |  **3.110 ns** | **0.0176 ns** | **0.0147 ns** |  **3.105 ns** |  **1.00** |    **0.01** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 1000  |  3.778 ns | 0.0891 ns | 0.1561 ns |  3.700 ns |  1.21 |    0.05 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 1000  |  4.430 ns | 0.1211 ns | 0.1011 ns |  4.387 ns |  1.42 |    0.03 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 1000  |  9.392 ns | 0.0230 ns | 0.0204 ns |  9.393 ns |  3.02 |    0.02 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 1000  | 38.164 ns | 0.4094 ns | 0.3629 ns | 38.122 ns | 12.27 |    0.13 |    5 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 1000  |  3.795 ns | 0.0901 ns | 0.1554 ns |  3.732 ns |  1.22 |    0.05 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 1000  |  4.664 ns | 0.1155 ns | 0.1023 ns |  4.629 ns |  1.50 |    0.03 |    3 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 1000  |  2.490 ns | 0.0114 ns | 0.0095 ns |  2.489 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 1000  |  2.436 ns | 0.0092 ns | 0.0077 ns |  2.436 ns |  0.98 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 1000  |  3.167 ns | 0.0210 ns | 0.0164 ns |  3.165 ns |  1.27 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 1000  |  8.898 ns | 0.0194 ns | 0.0172 ns |  8.899 ns |  3.57 |    0.01 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 1000  | 32.623 ns | 0.1379 ns | 0.1077 ns | 32.606 ns | 13.10 |    0.06 |    5 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 1000  |  2.527 ns | 0.0326 ns | 0.0272 ns |  2.518 ns |  1.01 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 1000  |  3.282 ns | 0.0129 ns | 0.0108 ns |  3.281 ns |  1.32 |    0.01 |    3 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupString                                              | 1000  | 12.315 ns | 0.0351 ns | 0.0311 ns | 12.326 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 1000  | 28.944 ns | 0.0733 ns | 0.0685 ns | 28.946 ns |  2.35 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 1000  | 29.414 ns | 0.0783 ns | 0.0732 ns | 29.419 ns |  2.39 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 1000  | 34.534 ns | 0.0582 ns | 0.0544 ns | 34.535 ns |  2.80 |    0.01 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 1000  | 31.732 ns | 0.0866 ns | 0.0768 ns | 31.733 ns |  2.58 |    0.01 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 1000  | 33.298 ns | 0.0897 ns | 0.0795 ns | 33.276 ns |  2.70 |    0.01 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 1000  | 32.497 ns | 0.1021 ns | 0.0955 ns | 32.468 ns |  2.64 |    0.01 |    3 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **10000** |  **3.134 ns** | **0.0278 ns** | **0.0232 ns** |  **3.126 ns** |  **1.00** |    **0.01** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 10000 |  3.598 ns | 0.0070 ns | 0.0054 ns |  3.600 ns |  1.15 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 10000 |  4.309 ns | 0.0130 ns | 0.0109 ns |  4.310 ns |  1.38 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 10000 |  9.694 ns | 0.1476 ns | 0.1919 ns |  9.639 ns |  3.09 |    0.06 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 10000 | 42.182 ns | 0.5984 ns | 0.4997 ns | 42.034 ns | 13.46 |    0.18 |    6 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 10000 |  3.643 ns | 0.0106 ns | 0.0083 ns |  3.645 ns |  1.16 |    0.01 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 10000 |  4.616 ns | 0.0052 ns | 0.0044 ns |  4.616 ns |  1.47 |    0.01 |    4 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 10000 |  2.418 ns | 0.0061 ns | 0.0057 ns |  2.420 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 10000 |  2.525 ns | 0.0102 ns | 0.0080 ns |  2.524 ns |  1.04 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 10000 |  3.307 ns | 0.0417 ns | 0.0348 ns |  3.298 ns |  1.37 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 10000 |  8.880 ns | 0.0224 ns | 0.0187 ns |  8.879 ns |  3.67 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 10000 | 33.390 ns | 0.1075 ns | 0.0953 ns | 33.341 ns | 13.81 |    0.05 |    4 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 10000 |  2.469 ns | 0.0471 ns | 0.0368 ns |  2.453 ns |  1.02 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 10000 |  3.430 ns | 0.0135 ns | 0.0113 ns |  3.430 ns |  1.42 |    0.01 |    2 |      - |         - |          NA |
|                                                           |       |           |           |           |           |       |         |      |        |           |             |
| LookupString                                              | 10000 | 12.608 ns | 0.0299 ns | 0.0265 ns | 12.606 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 10000 | 28.924 ns | 0.1249 ns | 0.1168 ns | 28.940 ns |  2.29 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 10000 | 29.584 ns | 0.1035 ns | 0.0968 ns | 29.567 ns |  2.35 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 10000 | 34.643 ns | 0.1551 ns | 0.1211 ns | 34.665 ns |  2.75 |    0.01 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 10000 | 31.713 ns | 0.2013 ns | 0.1784 ns | 31.717 ns |  2.52 |    0.01 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 10000 | 33.070 ns | 0.0545 ns | 0.0483 ns | 33.057 ns |  2.62 |    0.01 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 10000 | 31.847 ns | 0.0653 ns | 0.0611 ns | 31.832 ns |  2.53 |    0.01 |    3 |      - |         - |          NA |
