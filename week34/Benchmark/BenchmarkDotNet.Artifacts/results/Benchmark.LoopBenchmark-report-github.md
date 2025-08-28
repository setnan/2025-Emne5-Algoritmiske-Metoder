```

BenchmarkDotNet v0.15.2, Linux Fedora Linux 42 (Workstation Edition)
AMD Ryzen 7 PRO 6850U with Radeon Graphics 4.77GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.109
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX2


```
| Method             | Mean      | Error    | StdDev   | Rank | Allocated |
|------------------- |----------:|---------:|---------:|-----:|----------:|
| SumWithForLoop     | 477.31 ns | 5.283 ns | 4.942 ns |    3 |         - |
| SumWithWhileLoop   | 478.29 ns | 4.137 ns | 3.667 ns |    3 |         - |
| SumWithForEachLoop | 267.42 ns | 2.759 ns | 2.581 ns |    2 |         - |
| SumWithLinq        |  70.49 ns | 0.547 ns | 0.512 ns |    1 |         - |
