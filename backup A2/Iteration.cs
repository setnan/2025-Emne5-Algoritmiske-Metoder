namespace Oppgave1;

public static class Iteration
{
    // Oppgave 1B (samme range og returtype som 1A)
    public static long FibIterative(int n)
    {
        if (n < 0 || n > 92)
            throw new ArgumentOutOfRangeException(nameof(n), "n må være mellom 0 og 92 (inkludert).");
        if (n == 0) return 0;
        if (n == 1) return 1;

        long a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            long next = a + b;
            a = b;
            b = next;
        }
        return b;
    }
}
