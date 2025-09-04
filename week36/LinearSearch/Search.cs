namespace LinearSearch;

public static class Search
{
    // [0, 1, 2, 3, 4, 5] = 3 -> indexes
    // [4, 66, 33, 2, 12, 1] = 12 -> return 4
    // Returns the index of the target if found, otherwise -1
    public static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
                return i; // Target found, returnerer indexen
        }
        return -1; // Target not found
    }
}