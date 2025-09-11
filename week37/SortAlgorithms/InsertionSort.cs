namespace SortAlgorithms;

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];

            // Indeks for det forrige elementet
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
            {
                // Flytt elemntet til høyre
                array[j + 1] = key;
                j--;

            }

            array[j + 1] = key;
        }
    }
}