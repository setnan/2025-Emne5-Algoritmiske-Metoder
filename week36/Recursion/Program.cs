namespace week36.Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Factorial of 4 is: {RecursiveMethods.Factorial(4)}");
        }

        // Benchmark testing

        BenchmarkRunner.Run<SumBenchmark>();
    }
}