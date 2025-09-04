var people = new[]
{
    new Person(){FirstName = "John", LastName = "Doe", Age = 30},
    new Person(){FirstName = "Mary", LastName = "Hopper", Age = 50},
    new Person(){FirstName = "Alan", LastName = "Turing", Age = 60},
    new Person(){FirstName = "Bjarne", LastName = "Hansen", Age = 35},
    new Person(){FirstName = "Gunn", LastName = "Olsen", Age = 24},
};

Console.WriteLine("Before sorting:");
foreach (var person in people)
    Console.WriteLine(person);

Console.WriteLine("-------------------");

Console.WriteLine("After sorting:");
Array.Sort(people);
foreach (var person in people)
    Console.WriteLine(person);

Console.WriteLine("-------------------");

int idx = Array.BinarySearch(people,
new Person2() { LastName = "Hansen", FirstName = "Bjarne", Age = 0 },
new LastNameComparer());

Console.WriteLine(
    idx >= 0
    ? $"Found at index {idx}: {people[idx]}"
    : "\n Not found"
    );