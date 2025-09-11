using Sort

int[] array = [12, 55, 22, 4, 56, 2, 33, 1, 99, 23];

Console.WriteLine($"Før sortering: {string.Join(", ", array)}");

InsertionSort.Sort(array);

Console.WriteLine($"Etter sortering: {string.Join(", ", array)}");