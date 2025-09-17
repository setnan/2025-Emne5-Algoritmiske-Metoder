namespace Oppgave1;

public class Iteration
{
    public int FibonacciIter(int n)
    {
        if (n < 0 || n > 92)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be between 0 and 92 inclusive.");
        }
        if (n == 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, fib = 0;
        for (int i = 2; i <= n; i++)
        {
            fib = a + b;
            a = b;
            b = fib;
        }
        return fib;
    }
}