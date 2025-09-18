namespace Oppgave1;

public static class Recursion
{
    // Oppgave 1A
    public static long FibRecursive(int n)
    {
        if (n < 0 || n > 92)
            throw new ArgumentOutOfRangeException(nameof(n), "n må være mellom 0 og 92 (inkludert).");
        if (n < 2) return n; // 0 -> 0, 1 -> 1
        return FibRecursive(n - 1) + FibRecursive(n - 2);
    }
}
