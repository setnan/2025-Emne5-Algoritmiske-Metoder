namespace CustomDataBinarySearch;

public class Person : IComparable<Person>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public int CompareTo(Person? other)
    {
        if (other == null) return 1;

        int byLastName =
            string.Compare(LastName, other.LastName, StringComparison.OrdinalIgnoreCase); // Ikke case-sensitiv
        if (byLastName != 0)
            return byLastName;

        if (byLastName != 0)
            return byLastName;

        int byFirstName =
            string.Compare(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase); // Ikke case-sensitiv
        if (byFirstName != 0)
            return byFirstName;

        if (byFirstName != 0)
            return byFirstName;

        if (Age != other.Age)
            return Age.CompareTo(other.Age);

    }

    public override string ToString()
    {
        return $"Firstname: {FirstName}, Lastname: {LastName}, Age: {Age}";
    }

    public class Person2 : IComparable<Person2>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
}