```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.100-preview.3.24204.13
  [Host]     : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD


```
| Method                                                        | N     | Mean       | Error     | StdDev    | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|-------------------------------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-----:|----------:|------------:|
| **LookupTraditionalGuid**                                         | **1**     |  **3.5822 ns** | **0.0344 ns** | **0.0269 ns** |  **1.00** |    **0.00** |    **3** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKeyGuid                     | 1     |  4.1452 ns | 0.0678 ns | 0.0634 ns |  1.15 |    0.01 |    4 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyGuidWithCustomComparer   | 1     |  4.7543 ns | 0.0861 ns | 0.0719 ns |  1.33 |    0.02 |    5 |         - |          NA |
| LookupFrozenGuid                                              | 1     |  9.0869 ns | 0.0731 ns | 0.0684 ns |  2.54 |    0.03 |    6 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuid                          | 1     |  0.6808 ns | 0.0184 ns | 0.0172 ns |  0.19 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuidWithCustomComparer        | 1     |  1.8596 ns | 0.0202 ns | 0.0168 ns |  0.52 |    0.01 |    2 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalInt                                          | 1     |  3.0868 ns | 0.0129 ns | 0.0121 ns |  1.00 |    0.00 |    5 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyInt                      | 1     |  2.8943 ns | 0.0121 ns | 0.0113 ns |  0.94 |    0.01 |    4 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyIntWithCustomComparer    | 1     |  3.3425 ns | 0.0181 ns | 0.0160 ns |  1.08 |    0.01 |    6 |         - |          NA |
| LookupFrozenInt                                               | 1     |  1.5621 ns | 0.0113 ns | 0.0106 ns |  0.51 |    0.00 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyInt                           | 1     |  0.6317 ns | 0.0072 ns | 0.0067 ns |  0.20 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyIntWithCustomComparer         | 1     |  1.7045 ns | 0.0249 ns | 0.0233 ns |  0.55 |    0.01 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalString                                       | 1     | 11.5051 ns | 0.0281 ns | 0.0263 ns |  1.00 |    0.00 |    4 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyString                   | 1     | 31.1992 ns | 0.1359 ns | 0.1271 ns |  2.71 |    0.01 |    6 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyStringWithCustomComparer | 1     | 27.1163 ns | 0.0660 ns | 0.0551 ns |  2.36 |    0.01 |    5 |         - |          NA |
| LookupFrozenString                                            | 1     |  2.8913 ns | 0.0217 ns | 0.0203 ns |  0.25 |    0.00 |    3 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyString                        | 1     |  0.8930 ns | 0.0033 ns | 0.0028 ns |  0.08 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyStringWithCustomComparer      | 1     |  2.6041 ns | 0.0113 ns | 0.0100 ns |  0.23 |    0.00 |    2 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| **LookupTraditionalGuid**                                         | **10**    |  **3.6498 ns** | **0.0374 ns** | **0.0331 ns** |  **1.00** |    **0.00** |    **1** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKeyGuid                     | 10    |  4.1649 ns | 0.0556 ns | 0.0520 ns |  1.14 |    0.01 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyGuidWithCustomComparer   | 10    |  4.5316 ns | 0.0288 ns | 0.0241 ns |  1.24 |    0.01 |    3 |         - |          NA |
| LookupFrozenGuid                                              | 10    | 10.1496 ns | 0.0682 ns | 0.0638 ns |  2.78 |    0.02 |    5 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuid                          | 10    |  8.6904 ns | 0.1452 ns | 0.1359 ns |  2.38 |    0.06 |    4 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuidWithCustomComparer        | 10    |  4.4707 ns | 0.0225 ns | 0.0176 ns |  1.23 |    0.02 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalInt                                          | 10    |  3.0749 ns | 0.0302 ns | 0.0252 ns |  1.00 |    0.00 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyInt                      | 10    |  2.8236 ns | 0.0108 ns | 0.0096 ns |  0.92 |    0.01 |    1 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyIntWithCustomComparer    | 10    |  3.2971 ns | 0.0149 ns | 0.0132 ns |  1.07 |    0.01 |    4 |         - |          NA |
| LookupFrozenInt                                               | 10    | 13.9889 ns | 0.0335 ns | 0.0313 ns |  4.55 |    0.04 |    6 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyInt                           | 10    |  5.1962 ns | 0.1484 ns | 0.1524 ns |  1.69 |    0.04 |    5 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyIntWithCustomComparer         | 10    |  3.1321 ns | 0.0156 ns | 0.0146 ns |  1.02 |    0.01 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalString                                       | 10    | 11.6154 ns | 0.0596 ns | 0.0498 ns |  1.00 |    0.00 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyString                   | 10    | 31.0888 ns | 0.0705 ns | 0.0625 ns |  2.68 |    0.01 |    5 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyStringWithCustomComparer | 10    | 27.1223 ns | 0.1298 ns | 0.1151 ns |  2.34 |    0.01 |    4 |         - |          NA |
| LookupFrozenString                                            | 10    |  3.5272 ns | 0.0224 ns | 0.0187 ns |  0.30 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyString                        | 10    | 41.4392 ns | 0.6562 ns | 0.6139 ns |  3.57 |    0.05 |    6 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyStringWithCustomComparer      | 10    | 26.5437 ns | 0.0973 ns | 0.0910 ns |  2.29 |    0.01 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| **LookupTraditionalGuid**                                         | **100**   |  **3.6592 ns** | **0.0609 ns** | **0.0570 ns** |  **1.00** |    **0.00** |    **1** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKeyGuid                     | 100   |  4.1773 ns | 0.0143 ns | 0.0119 ns |  1.14 |    0.02 |    3 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyGuidWithCustomComparer   | 100   |  4.4013 ns | 0.0726 ns | 0.0679 ns |  1.20 |    0.01 |    4 |         - |          NA |
| LookupFrozenGuid                                              | 100   |  3.8696 ns | 0.1064 ns | 0.0944 ns |  1.06 |    0.03 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuid                          | 100   |  3.6643 ns | 0.0985 ns | 0.0922 ns |  1.00 |    0.03 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuidWithCustomComparer        | 100   |  4.6254 ns | 0.0144 ns | 0.0120 ns |  1.26 |    0.02 |    5 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalInt                                          | 100   |  3.1269 ns | 0.1041 ns | 0.1157 ns |  1.00 |    0.00 |    4 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyInt                      | 100   |  2.9621 ns | 0.0774 ns | 0.0724 ns |  0.95 |    0.03 |    3 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyIntWithCustomComparer    | 100   |  3.3904 ns | 0.0658 ns | 0.0616 ns |  1.09 |    0.04 |    5 |         - |          NA |
| LookupFrozenInt                                               | 100   |  1.3530 ns | 0.0182 ns | 0.0171 ns |  0.44 |    0.02 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyInt                           | 100   |  2.2000 ns | 0.0214 ns | 0.0190 ns |  0.71 |    0.02 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyIntWithCustomComparer         | 100   |  3.1473 ns | 0.0303 ns | 0.0283 ns |  1.01 |    0.04 |    4 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalString                                       | 100   | 11.9771 ns | 0.0137 ns | 0.0122 ns |  1.00 |    0.00 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyString                   | 100   | 30.8755 ns | 0.1421 ns | 0.1187 ns |  2.58 |    0.01 |    6 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyStringWithCustomComparer | 100   | 27.1268 ns | 0.1055 ns | 0.0881 ns |  2.26 |    0.01 |    4 |         - |          NA |
| LookupFrozenString                                            | 100   |  4.7020 ns | 0.0071 ns | 0.0059 ns |  0.39 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyString                        | 100   | 29.2874 ns | 0.2304 ns | 0.2155 ns |  2.44 |    0.02 |    5 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyStringWithCustomComparer      | 100   | 26.6226 ns | 0.2129 ns | 0.1992 ns |  2.22 |    0.02 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| **LookupTraditionalGuid**                                         | **1000**  |  **3.8297 ns** | **0.0419 ns** | **0.0350 ns** |  **1.00** |    **0.00** |    **2** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKeyGuid                     | 1000  |  4.1111 ns | 0.0486 ns | 0.0455 ns |  1.07 |    0.01 |    3 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyGuidWithCustomComparer   | 1000  |  4.5197 ns | 0.1198 ns | 0.1281 ns |  1.18 |    0.04 |    4 |         - |          NA |
| LookupFrozenGuid                                              | 1000  |  3.8753 ns | 0.1086 ns | 0.1016 ns |  1.01 |    0.02 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuid                          | 1000  |  3.6798 ns | 0.0740 ns | 0.0578 ns |  0.96 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuidWithCustomComparer        | 1000  |  4.7115 ns | 0.0810 ns | 0.0757 ns |  1.23 |    0.02 |    5 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalInt                                          | 1000  |  2.9002 ns | 0.0151 ns | 0.0141 ns |  1.00 |    0.00 |    4 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyInt                      | 1000  |  2.7656 ns | 0.0223 ns | 0.0209 ns |  0.95 |    0.01 |    3 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyIntWithCustomComparer    | 1000  |  3.2926 ns | 0.0146 ns | 0.0129 ns |  1.14 |    0.01 |    6 |         - |          NA |
| LookupFrozenInt                                               | 1000  |  1.6118 ns | 0.0157 ns | 0.0147 ns |  0.56 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyInt                           | 1000  |  2.1912 ns | 0.0288 ns | 0.0269 ns |  0.76 |    0.01 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyIntWithCustomComparer         | 1000  |  3.1477 ns | 0.0195 ns | 0.0182 ns |  1.09 |    0.01 |    5 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalString                                       | 1000  | 12.2621 ns | 0.2429 ns | 0.2272 ns |  1.00 |    0.00 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyString                   | 1000  | 32.2457 ns | 0.1722 ns | 0.1438 ns |  2.63 |    0.05 |    6 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyStringWithCustomComparer | 1000  | 28.9154 ns | 0.1445 ns | 0.1207 ns |  2.36 |    0.04 |    4 |         - |          NA |
| LookupFrozenString                                            | 1000  |  5.1700 ns | 0.0838 ns | 0.0784 ns |  0.42 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyString                        | 1000  | 30.4274 ns | 0.0979 ns | 0.0868 ns |  2.48 |    0.04 |    5 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyStringWithCustomComparer      | 1000  | 28.1762 ns | 0.2322 ns | 0.2058 ns |  2.30 |    0.04 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| **LookupTraditionalGuid**                                         | **10000** |  **3.7355 ns** | **0.0325 ns** | **0.0288 ns** |  **1.00** |    **0.00** |    **1** |         **-** |          **NA** |
| LookupTraditionalWithStronglyTypedKeyGuid                     | 10000 |  4.1537 ns | 0.0289 ns | 0.0271 ns |  1.11 |    0.00 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyGuidWithCustomComparer   | 10000 |  4.4967 ns | 0.0362 ns | 0.0302 ns |  1.20 |    0.00 |    3 |         - |          NA |
| LookupFrozenGuid                                              | 10000 |  4.1032 ns | 0.0679 ns | 0.0635 ns |  1.10 |    0.01 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuid                          | 10000 |  3.7644 ns | 0.0444 ns | 0.0415 ns |  1.01 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyGuidWithCustomComparer        | 10000 |  4.5448 ns | 0.0088 ns | 0.0068 ns |  1.22 |    0.01 |    3 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalInt                                          | 10000 |  2.9143 ns | 0.0260 ns | 0.0230 ns |  1.00 |    0.00 |    4 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyInt                      | 10000 |  2.8108 ns | 0.0071 ns | 0.0055 ns |  0.96 |    0.01 |    3 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyIntWithCustomComparer    | 10000 |  3.3883 ns | 0.0511 ns | 0.0427 ns |  1.16 |    0.02 |    6 |         - |          NA |
| LookupFrozenInt                                               | 10000 |  1.6535 ns | 0.0432 ns | 0.0404 ns |  0.57 |    0.01 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyInt                           | 10000 |  2.1932 ns | 0.0192 ns | 0.0170 ns |  0.75 |    0.01 |    2 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyIntWithCustomComparer         | 10000 |  3.1996 ns | 0.0468 ns | 0.0391 ns |  1.10 |    0.01 |    5 |         - |          NA |
|                                                               |       |            |           |           |       |         |      |           |             |
| LookupTraditionalString                                       | 10000 | 12.4047 ns | 0.0626 ns | 0.0555 ns |  1.00 |    0.00 |    2 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyString                   | 10000 | 32.4321 ns | 0.1069 ns | 0.1000 ns |  2.61 |    0.02 |    6 |         - |          NA |
| LookupTraditionalWithStronglyTypedKeyStringWithCustomComparer | 10000 | 28.6913 ns | 0.1314 ns | 0.1164 ns |  2.31 |    0.02 |    4 |         - |          NA |
| LookupFrozenString                                            | 10000 |  4.5755 ns | 0.0448 ns | 0.0397 ns |  0.37 |    0.00 |    1 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyString                        | 10000 | 30.5300 ns | 0.0900 ns | 0.0842 ns |  2.46 |    0.01 |    5 |         - |          NA |
| LookupFrozenWithStronglyTypedKeyStringWithCustomComparer      | 10000 | 28.1652 ns | 0.1430 ns | 0.1338 ns |  2.27 |    0.02 |    3 |         - |          NA |
