using System.Text;
using System.Buffers; 
using BenchmarkDotNet.Attributes;

namespace StringBenchmark;

[MemoryDiagnoser]
[RankColumn]
public class StringBuildBenchmark
{
    [Params(10, 1_000, 10_000, 100_000)]
    public int N;

    private const char C = 'x';

    [Benchmark(Baseline = true)]
    public string PlusOperator()
    {
        string s = string.Empty;
        for (int i = 0; i < N; i++)
            s += C;
        return s;
    }

    [Benchmark]
    public string StringBuilder_NoCapacity()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < N; i++)
            sb.Append(C);
        return sb.ToString();
    }

    [Benchmark]
    public string StringBuilder_WithCapacity()
    {
        var sb = new StringBuilder(N);
        for (int i = 0; i < N; i++)
            sb.Append(C);
        return sb.ToString();
    }

    [Benchmark]
    public string NewStringCtor()
    {
        return new string(C, N);
    }

    [Benchmark]
    public string Concat_EnumerableRepeat()
    {
        return string.Concat(Enumerable.Repeat("x", N));
    }

    [Benchmark]
    public string StringCreate_Fill()
    {
        return string.Create(N, C, (span, ch) =>
        {
            span.Fill(ch);
        });
    }
    [Benchmark]
    public string ArrayPoolFillThenCtor()
    {
        var array = ArrayPool<char>.Shared.Rent(N);
        try
        {
            for (int i = 0; i < N; i++)
                array[i] = C;
            return new string(array, 0, N);
        }
        finally
        {
            ArrayPool<char>.Shared.Return(array);
        }
    }
}