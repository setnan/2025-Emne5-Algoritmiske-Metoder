using System.Diagnostics;
using System;

int loopCount = 100_000_000;
int count = 6;

Console.WriteLine($"Sum of numbers from 1 to {count}: {SumNumbers(count)}");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

for (int i = 0; i < loopCount; i++)
{
    SumNumbers(count);
}

stopwatch.Stop();
Console.WriteLine($"Time taken for {loopCount} iterations: {stopwatch.ElapsedMilliseconds} ms");

int SumNumbers(int n)
{
    int sum = 0;
    for (int i = 1; i <= n; i++)
    {
        sum += i;
    }
    return sum;
}
