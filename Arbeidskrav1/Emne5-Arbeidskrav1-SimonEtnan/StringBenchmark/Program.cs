using BenchmarkDotNet.Running;

namespace StringBenchmark;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<StringBuildBenchmark>();
    }
}
