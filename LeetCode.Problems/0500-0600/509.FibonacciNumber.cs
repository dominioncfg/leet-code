public interface IFibonacciNumber
{
    public int Fib(int n);
}

public class FibonacciNumber : IFibonacciNumber
{
    public int Fib(int n)
    {
        var memo = new Dictionary<int, int>()
        {
            [0] = 0,
            [1] = 1,
        };
        return CalFib(n, memo);

    }

    public int CalFib(int n, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n))
            return memo[n];

        memo[n] = CalFib(n - 1, memo) + CalFib(n - 2, memo);
        return memo[n];
    }

}

public class FibonacciNumberIterative : IFibonacciNumber
{
    public int Fib(int n)
    {
        if (n == 0) return 0;

        if (n == 1) return 1;


        var minus2 = 0;
        var minus1 = 1;

        for (var i = 2; i < n; i++)
        {
            var next = minus2 + minus1;
            minus2 = minus1;
            minus1 = next;
        }

        return minus2 + minus1;
    }

}


public class FibonacciNumberRecursive : IFibonacciNumber
{
    public int Fib(int n)
    {
        if (n == 0) return 0;

        if (n == 1) return 1;

        return Fib(n - 1) + Fib(n - 2);
    }

}

