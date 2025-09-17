﻿namespace Oppgave1;

using BenchmarkDotNet.Running;



// testing
// Console.WriteLine($"Fibonacci of 0 is: {Recursion.Fibonacci(0)}");
// Console.WriteLine($"Fibonacci of 6 is: {Recursion.Fibonacci(6)}");
// Console.WriteLine($"Fibonacci of 10 is: {Recursion.Fibonacci(10)}");

// Console.WriteLine("--- --- --- --- ---");

// Console.WriteLine($"Iterative Fibonacci of 0 is: {Iteration.Fibonacci(0)}");
// Console.WriteLine($"Iterative Fibonacci of 6 is: {Iteration.Fibonacci(6)}");
// Console.WriteLine($"Iterative Fibonacci of 10 is: {Iteration.Fibonacci(10)}");

// Sum benchmark
BenchmarkRunner.Run<SumBenchmark>();
BenchmarkRunner.Run<FibonacciRecBenchmark>();

// FibonacciRec
BenchmarkRunner.Run<FibonacciIter>();