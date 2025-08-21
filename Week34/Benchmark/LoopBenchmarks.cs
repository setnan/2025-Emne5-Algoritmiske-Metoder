using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MemoryDiagnoser, RankColumn]
    public class LoopBenchmark
    {
        private int[] _data = new int[1000];

        [Benchmark]
        public int SumWithForLoop()
        {
            int sum = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                sum += _data[i];
            }
            return sum;
        }

        [Benchmark]
        public int SumWithWhileLoop()
        {
            int sum = 0;
            int i = 0;
            while (i < _data.Length)
            {
                sum += _data[i];
                i++;
            }
            return sum;
        }

        [Benchmark]
        public int SumWithForEachLoop()
        {
            int sum = 0;
            foreach (var item in _data)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int SumWithLinq()
        {
            return _data.Sum();
        }

    }
}