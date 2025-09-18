```

BenchmarkDotNet v0.15.2, Linux Fedora Linux 42 (Workstation Edition)
AMD Ryzen 7 PRO 6850U with Radeon Graphics 4.77GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.109
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX2


```
| Method   | N  | Mean             | Error          | StdDev         | Allocated |
|--------- |--- |-----------------:|---------------:|---------------:|----------:|
| **Rekursiv** | **5**  |        **16.564 ns** |      **0.3409 ns** |      **0.3789 ns** |         **-** |
| Iterativ | 5  |         2.021 ns |      0.0268 ns |      0.0250 ns |         - |
| **Rekursiv** | **10** |       **205.024 ns** |      **2.4888 ns** |      **2.0783 ns** |         **-** |
| Iterativ | 10 |         6.216 ns |      0.1467 ns |      0.1441 ns |         - |
| **Rekursiv** | **20** |    **28,632.599 ns** |    **556.5759 ns** |    **571.5625 ns** |         **-** |
| Iterativ | 20 |         9.314 ns |      0.1104 ns |      0.1033 ns |         - |
| **Rekursiv** | **30** | **3,501,049.766 ns** | **44,248.4162 ns** | **39,225.0684 ns** |         **-** |
| Iterativ | 30 |        20.867 ns |      0.1899 ns |      0.1483 ns |         - |
