using System;
using System.Collections.Generic;
using week36.LinearSearch;

// lager array[20], random numbers between 1 and 100, target = 50
// unique numbers

HashSet<int> uniqueNumbers = new();
while (uniqueNumbers.Count <= 20)
{
    uniqueNumbers.Add(Random.Shared.Next(1, 101));
}

int[] array = uniqueNumbers.ToArray();
Console.WriteLine($"Array: [{string.Join(", ", array)}]");

int target = int.Parse(Console.ReadLine()!); 
int result = Search.LinearSearch(array, target);

Console.WriteLine(
    result == -1
    ? $"Element {target} not found in the array."
    : $"Element {target} found at index {result}."
    );
