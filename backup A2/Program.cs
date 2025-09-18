

namespace Oppgave1
{

using BenchmarkDotNet.Running;

}


// Test av funksjonene
// Console.WriteLine("Rekursiv:");
// Console.WriteLine(Recursion.FibRecursive(0));   // 0
// Console.WriteLine(Recursion.FibRecursive(6));   // 8
// Console.WriteLine(Recursion.FibRecursive(10));  // 55

// Console.WriteLine("---");

// Console.WriteLine("Iterativ:");
// Console.WriteLine(Iteration.FibIterative(0));   // 0
// Console.WriteLine(Iteration.FibIterative(6));   // 8
// Console.WriteLine(Iteration.FibIterative(10));  // 55

BenchmarkRunner.Run<FibonacciBenchmark>();
