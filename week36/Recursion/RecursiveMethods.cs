namespace week36.Recursion
{
    public static class RecursiveMethods
    {
        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers do not have a factorial.");

            // Base case
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1); // Recursive case
        }
    }
}