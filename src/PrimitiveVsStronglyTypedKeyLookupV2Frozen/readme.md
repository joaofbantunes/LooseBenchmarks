```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.1 (24B83) [Darwin 24.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


```
| Method                                                    | N     | Mean       | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
| **LookupGuid**                                                | **1**     |  **9.6138 ns** | **0.0415 ns** | **0.0346 ns** |  **1.00** |    **0.00** |    **4** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 1     |  1.3416 ns | 0.0521 ns | 0.0462 ns |  0.14 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 1     |  1.6051 ns | 0.0773 ns | 0.1108 ns |  0.17 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 1     |  5.7150 ns | 0.1586 ns | 0.1889 ns |  0.59 |    0.02 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 1     | 39.7835 ns | 0.0819 ns | 0.0726 ns |  4.14 |    0.02 |    5 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 1     |  1.2668 ns | 0.0083 ns | 0.0070 ns |  0.13 |    0.00 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 1     |  1.6265 ns | 0.0080 ns | 0.0067 ns |  0.17 |    0.00 |    2 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 1     |  1.2729 ns | 0.0263 ns | 0.0219 ns |  1.00 |    0.02 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 1     |  0.6647 ns | 0.0217 ns | 0.0193 ns |  0.52 |    0.02 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 1     |  1.8321 ns | 0.0164 ns | 0.0145 ns |  1.44 |    0.03 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 1     |  5.4806 ns | 0.0335 ns | 0.0314 ns |  4.31 |    0.08 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 1     | 31.5077 ns | 0.0968 ns | 0.0858 ns | 24.76 |    0.42 |    6 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 1     |  0.6580 ns | 0.0118 ns | 0.0105 ns |  0.52 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 1     |  1.6703 ns | 0.0069 ns | 0.0065 ns |  1.31 |    0.02 |    3 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupString                                              | 1     |  2.9329 ns | 0.0071 ns | 0.0066 ns |  1.00 |    0.00 |    3 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 1     |  1.0441 ns | 0.0054 ns | 0.0050 ns |  0.36 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 1     |  2.0252 ns | 0.0057 ns | 0.0050 ns |  0.69 |    0.00 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 1     |  5.4386 ns | 0.0224 ns | 0.0199 ns |  1.85 |    0.01 |    6 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 1     |  3.5680 ns | 0.0574 ns | 0.0448 ns |  1.22 |    0.01 |    5 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 1     |  1.0655 ns | 0.0104 ns | 0.0098 ns |  0.36 |    0.00 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 1     |  3.0610 ns | 0.0169 ns | 0.0132 ns |  1.04 |    0.00 |    4 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **10**    | **15.0699 ns** | **0.0478 ns** | **0.0399 ns** |  **1.00** |    **0.00** |    **6** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 10    |  5.1808 ns | 0.0154 ns | 0.0129 ns |  0.34 |    0.00 |    4 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 10    |  4.8389 ns | 0.0152 ns | 0.0142 ns |  0.32 |    0.00 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 10    | 10.3597 ns | 0.0271 ns | 0.0226 ns |  0.69 |    0.00 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 10    | 39.6034 ns | 0.1759 ns | 0.1373 ns |  2.63 |    0.01 |    7 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 10    |  4.9969 ns | 0.0172 ns | 0.0134 ns |  0.33 |    0.00 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 10    |  4.7053 ns | 0.0198 ns | 0.0155 ns |  0.31 |    0.00 |    1 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 10    | 14.5147 ns | 0.0899 ns | 0.0841 ns |  1.00 |    0.01 |    6 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 10    |  4.7863 ns | 0.1011 ns | 0.0789 ns |  0.33 |    0.01 |    3 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 10    |  3.5372 ns | 0.0199 ns | 0.0176 ns |  0.24 |    0.00 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 10    |  9.4715 ns | 0.1844 ns | 0.1539 ns |  0.65 |    0.01 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 10    | 35.9399 ns | 0.1305 ns | 0.1157 ns |  2.48 |    0.02 |    7 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 10    |  5.2594 ns | 0.0219 ns | 0.0194 ns |  0.36 |    0.00 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 10    |  3.2657 ns | 0.0132 ns | 0.0123 ns |  0.22 |    0.00 |    1 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupString                                              | 10    |  3.2670 ns | 0.0601 ns | 0.0533 ns |  1.00 |    0.02 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 10    | 34.5829 ns | 0.1774 ns | 0.1660 ns | 10.59 |    0.17 |    4 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 10    | 28.8464 ns | 0.0992 ns | 0.0879 ns |  8.83 |    0.14 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 10    | 33.9967 ns | 0.1035 ns | 0.0864 ns | 10.41 |    0.16 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 10    | 30.7473 ns | 0.1328 ns | 0.1037 ns |  9.41 |    0.15 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 10    | 34.7184 ns | 0.1501 ns | 0.1253 ns | 10.63 |    0.17 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 10    | 30.2062 ns | 0.1023 ns | 0.0907 ns |  9.25 |    0.15 |    3 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **100**   |  **3.6490 ns** | **0.0290 ns** | **0.0226 ns** |  **1.00** |    **0.01** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 100   |  3.7642 ns | 0.0537 ns | 0.0476 ns |  1.03 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 100   |  4.6090 ns | 0.0138 ns | 0.0129 ns |  1.26 |    0.01 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 100   | 10.1136 ns | 0.0372 ns | 0.0348 ns |  2.77 |    0.02 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 100   | 38.9390 ns | 0.2652 ns | 0.2351 ns | 10.67 |    0.09 |    4 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 100   |  3.6653 ns | 0.0151 ns | 0.0141 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 100   |  4.6290 ns | 0.0174 ns | 0.0163 ns |  1.27 |    0.01 |    2 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 100   |  1.4725 ns | 0.0089 ns | 0.0083 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 100   |  2.3953 ns | 0.0256 ns | 0.0227 ns |  1.63 |    0.02 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 100   |  3.4226 ns | 0.0331 ns | 0.0276 ns |  2.32 |    0.02 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 100   |  9.2846 ns | 0.0288 ns | 0.0269 ns |  6.31 |    0.04 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 100   | 33.2474 ns | 0.1953 ns | 0.1731 ns | 22.58 |    0.17 |    6 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 100   |  2.3480 ns | 0.0150 ns | 0.0140 ns |  1.59 |    0.01 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 100   |  3.2410 ns | 0.0128 ns | 0.0120 ns |  2.20 |    0.01 |    3 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupString                                              | 100   |  4.4080 ns | 0.0152 ns | 0.0142 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 100   | 28.1294 ns | 0.1483 ns | 0.1314 ns |  6.38 |    0.04 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 100   | 28.9493 ns | 0.1658 ns | 0.1294 ns |  6.57 |    0.03 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 100   | 33.7167 ns | 0.0894 ns | 0.0698 ns |  7.65 |    0.03 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 100   | 30.5530 ns | 0.2746 ns | 0.2293 ns |  6.93 |    0.05 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 100   | 30.7479 ns | 0.0944 ns | 0.0789 ns |  6.98 |    0.03 |    4 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 100   | 30.2121 ns | 0.1277 ns | 0.1067 ns |  6.85 |    0.03 |    4 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **1000**  |  **3.5019 ns** | **0.0123 ns** | **0.0115 ns** |  **1.00** |    **0.00** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 1000  |  3.6318 ns | 0.0235 ns | 0.0220 ns |  1.04 |    0.01 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 1000  |  4.6565 ns | 0.0189 ns | 0.0147 ns |  1.33 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 1000  | 10.0208 ns | 0.0231 ns | 0.0216 ns |  2.86 |    0.01 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 1000  | 38.8542 ns | 0.1868 ns | 0.1747 ns | 11.10 |    0.06 |    5 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 1000  |  3.6446 ns | 0.0202 ns | 0.0189 ns |  1.04 |    0.01 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 1000  |  4.6101 ns | 0.0441 ns | 0.0368 ns |  1.32 |    0.01 |    3 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 1000  |  1.5092 ns | 0.0069 ns | 0.0064 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 1000  |  2.4765 ns | 0.0097 ns | 0.0076 ns |  1.64 |    0.01 |    3 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 1000  |  3.2048 ns | 0.0447 ns | 0.0373 ns |  2.12 |    0.03 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 1000  |  9.2704 ns | 0.0228 ns | 0.0214 ns |  6.14 |    0.03 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 1000  | 35.0905 ns | 0.1770 ns | 0.1569 ns | 23.25 |    0.14 |    6 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 1000  |  2.3569 ns | 0.0236 ns | 0.0209 ns |  1.56 |    0.01 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 1000  |  3.2566 ns | 0.0150 ns | 0.0125 ns |  2.16 |    0.01 |    4 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupString                                              | 1000  |  4.7957 ns | 0.0364 ns | 0.0341 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 1000  | 30.6270 ns | 0.0778 ns | 0.0728 ns |  6.39 |    0.05 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 1000  | 30.8848 ns | 0.0683 ns | 0.0639 ns |  6.44 |    0.05 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 1000  | 35.3070 ns | 0.0801 ns | 0.0669 ns |  7.36 |    0.05 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 1000  | 32.4873 ns | 0.1317 ns | 0.1168 ns |  6.77 |    0.05 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 1000  | 32.3641 ns | 0.0869 ns | 0.0770 ns |  6.75 |    0.05 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 1000  | 31.8325 ns | 0.0918 ns | 0.0859 ns |  6.64 |    0.05 |    3 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| **LookupGuid**                                                | **10000** |  **3.5241 ns** | **0.0141 ns** | **0.0125 ns** |  **1.00** |    **0.00** |    **1** |      **-** |         **-** |          **NA** |
| LookupWithStronglyTypedKeyGuid                            | 10000 |  3.6556 ns | 0.0093 ns | 0.0083 ns |  1.04 |    0.00 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyGuidWithCustomComparer          | 10000 |  4.6161 ns | 0.0183 ns | 0.0171 ns |  1.31 |    0.01 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuid                         | 10000 | 10.0427 ns | 0.0408 ns | 0.0341 ns |  2.85 |    0.01 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyGuidWithCustomComparer       | 10000 | 42.3750 ns | 0.0738 ns | 0.0616 ns | 12.02 |    0.04 |    6 | 0.0051 |      32 B |          NA |
| LookupWithGenericStronglyTypedKeyGuid                     | 10000 |  3.6834 ns | 0.0245 ns | 0.0229 ns |  1.05 |    0.01 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyGuidWithCustomComparer   | 10000 |  5.0856 ns | 0.0114 ns | 0.0095 ns |  1.44 |    0.01 |    4 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupInt                                                 | 10000 |  1.4540 ns | 0.0550 ns | 0.0459 ns |  1.00 |    0.04 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyInt                             | 10000 |  2.3758 ns | 0.0364 ns | 0.0304 ns |  1.64 |    0.05 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyIntWithCustomComparer           | 10000 |  3.2658 ns | 0.0085 ns | 0.0075 ns |  2.25 |    0.07 |    3 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyInt                          | 10000 |  9.4169 ns | 0.0265 ns | 0.0221 ns |  6.48 |    0.19 |    5 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyIntWithCustomComparer        | 10000 | 35.7045 ns | 0.1177 ns | 0.1043 ns | 24.58 |    0.72 |    6 | 0.0038 |      24 B |          NA |
| LookupWithGenericStronglyTypedKeyInt                      | 10000 |  2.4337 ns | 0.0150 ns | 0.0125 ns |  1.68 |    0.05 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyIntWithCustomComparer    | 10000 |  3.4810 ns | 0.0631 ns | 0.0591 ns |  2.40 |    0.08 |    4 |      - |         - |          NA |
|                                                           |       |            |           |           |       |         |      |        |           |             |
| LookupString                                              | 10000 |  3.9659 ns | 0.0348 ns | 0.0271 ns |  1.00 |    0.01 |    1 |      - |         - |          NA |
| LookupWithStronglyTypedKeyString                          | 10000 | 30.7039 ns | 0.0896 ns | 0.0838 ns |  7.74 |    0.05 |    2 |      - |         - |          NA |
| LookupWithStronglyTypedKeyStringWithCustomComparer        | 10000 | 30.9162 ns | 0.1427 ns | 0.1265 ns |  7.80 |    0.06 |    2 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyString                       | 10000 | 36.1908 ns | 0.0997 ns | 0.0932 ns |  9.13 |    0.06 |    4 |      - |         - |          NA |
| LookupWithRefStronglyTypedKeyStringWithCustomComparer     | 10000 | 32.5662 ns | 0.3740 ns | 0.2920 ns |  8.21 |    0.09 |    3 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyString                   | 10000 | 31.4359 ns | 0.2223 ns | 0.1856 ns |  7.93 |    0.07 |    2 |      - |         - |          NA |
| LookupWithGenericStronglyTypedKeyStringWithCustomComparer | 10000 | 31.0418 ns | 0.1645 ns | 0.1538 ns |  7.83 |    0.06 |    2 |      - |         - |          NA |
