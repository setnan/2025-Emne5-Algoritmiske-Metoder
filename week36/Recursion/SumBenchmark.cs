
namespace Recursion;

// Benchmarking class to compare performance of different sum methods
public class SumBenchmark
{

    [Params(10, 100, 1000, 5_000)]
    public int N { get; set; }

    [Benchmark]
    public long SumPositiveNumbersInLoop() => RecursiveSum(N);
    [Benchmark]
    public long SumPositiveWithLoop() => LoopSum(N);


    private static long RecursiveSum(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers do not have a factorial.");

            // Base case
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1); // Recursive case
        }

    // SumPositiveNumbersRecursive(5) = 5 + 4 + 3 + 2 + 1
    private static long SumPositiveNumbersRecursive(int n)
    {
        if (n < 0)
            throw new ArgumentException("Argument n must be non-negative.");

        // Base case
        if (n <= 1) return n;

        // Recursive case
        return n + SumPositiveNumbersRecursive(n - 1);
    }
}