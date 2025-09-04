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
    public string PlusOperator()    // Baseline
    {
        string s = string.Empty;    // Starter med en tom streng
        for (int i = 0; i < N; i++) // Legger til tegnet N ganger
            s += C;                 // Oppretter mange mellomliggende strenger
        return s;                   // Returnerer den ferdige strengen
    }

    [Benchmark]
    public string StringBuilder_NoCapacity()
    {
        var sb = new StringBuilder();   // Starter med en tom StringBuilder
        for (int i = 0; i < N; i++)     // Legger til tegnet N ganger
            sb.Append(C);               // Kan kreve flere allokeringer
        return sb.ToString();           
    }

    [Benchmark]
    public string StringBuilder_WithCapacity()
    {
        var sb = new StringBuilder(N);  // Starter med kapasitet N
        for (int i = 0; i < N; i++)     // Legger til tegnet N ganger
            sb.Append(C);               // Unngår ekstra allokeringer
        return sb.ToString();           
    }

    [Benchmark]
    public string NewStringCtor()
    {
        return new string(C, N);        // Direkte konstruksjon av strengen
    }

    [Benchmark]
    public string Concat_EnumerableRepeat()
    {
        return string.Concat(Enumerable.Repeat("x", N));
    }                                   // Returner den ferdige strengen

    [Benchmark]
    public string StringCreate_Fill()
    {
        return string.Create(N, C, (span, ch) => // Allokerer og fyller i ett kall
        {
            span.Fill(ch);              // Fyller hele span med tegnet
        });
    }
    [Benchmark]
    public string ArrayPoolFillThenCtor()
    {
        var array = ArrayPool<char>.Shared.Rent(N); // Leier et array fra poolen
        try
        {
            for (int i = 0; i < N; i++)             // Fyll arrayet med tegnet
                array[i] = C;                       // Lager en streng fra arrayet
            return new string(array, 0, N);         // Returner den ferdige strengen
        }
        finally
        {
            ArrayPool<char>.Shared.Return(array);   // Returner arrayet til poolen
        }
    }
}