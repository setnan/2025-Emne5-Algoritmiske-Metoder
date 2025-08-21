```

BenchmarkDotNet v0.15.2, Linux Fedora Linux 42 (Workstation Edition)
AMD Ryzen 7 PRO 6850U with Radeon Graphics 4.77GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.109
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX2


```
| Method         | Mean     | Error   | StdDev  |
|--------------- |---------:|--------:|--------:|
| SumWithForLoop | 480.9 ns | 9.23 ns | 9.48 ns |
