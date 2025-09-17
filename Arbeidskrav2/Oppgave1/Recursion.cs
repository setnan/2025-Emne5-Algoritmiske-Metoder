namespace Oppgave1;

public class Recursion
{

    public static int FibonacciRec(int n)
    {
        if (n < 0 || n > 92)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be between 0 and 92 inclusive.");
        }
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciRec(n - 1) + FibonacciRec(n - 2);
    }

    public static int FibRecursive(int n)
    {
        if (n < 0 || n > 92)
            throw new ArgumentOutOfRangeException(nameof(n), "n må være mellom 0 og 92 (inkludert).");

        if (n < 2) return n;
        return FibRecursive(n - 1) + FibRecursive(n - 2);
    }
}
