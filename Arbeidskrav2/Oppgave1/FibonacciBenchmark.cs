using BenchmarkDotNet.Attributes;

namespace Oppgave1;

[MemoryDiagnoser]
public class FibonacciBenchmark
{
    [Params(5, 10, 20, 30)]
    public int N { get; set; }

    [Benchmark]
    public long Rekursiv() => Recursion.FibRecursive(N);

    [Benchmark]
    public long Iterativ() => Iteration.FibIterative(N);
}
