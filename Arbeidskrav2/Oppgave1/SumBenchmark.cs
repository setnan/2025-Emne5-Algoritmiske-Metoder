namespace Oppgave1;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
// denne skal være tilgjengelig for program.cs
public class SumBenchmark
{
    [Params(10, 100, 1000, 10000)]

    public int N { get; set; }

    [Benchmark]
    public int RecursionSum() => Recursion.Sum(N);

    [Benchmark]
    public int IterationSum() => Iteration.Sum(N);

    private static int FibonacciIter(int n)
    {
        if (n <= 1)
            throw new ArgumentOutOfRangeException("n", "n must be greater than 1");
        int a = 0;
        int b = 1;
        for (int i = 2; i <= n; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return b;
    }

    private static int FibonacciRec(int n)
    {
        if (n <= 1)
            throw new ArgumentOutOfRangeException("n", "n must be greater than 1");
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciRec(n - 1) + FibonacciRec(n - 2);
    }


}



