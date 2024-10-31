public interface IUniquePathsCalculator
{
    public int UniquePaths(int m, int n);
}


public class UniquePathsCalculatorWithBottomUpTablulation : IUniquePathsCalculator
{
    public int UniquePaths(int m, int n)
    {
        var dp = new int[m, n];
        dp[0, 0] = 1;

        for (int i = 1; i < m * n; i++)
        {
            var mI = i / n;
            var nI = i % n;

            var leftPostion = 0;
            var topPostion = 0;
            if (mI > 0)
            {
                topPostion = dp[mI - 1, nI];
            }

            if (nI > 0)
            {
                leftPostion = dp[mI, nI - 1];
            }

            dp[mI, nI] = leftPostion + topPostion;
        }


        return dp[m - 1, n - 1];
    }
}



public class UniquePathsCalculatorWithTopDownMemo : IUniquePathsCalculator
{
    public int UniquePaths(int m, int n)
    {
        var memo = new Dictionary<(int, int), int>()
        {
            [(1, 1)] = 1,
        };
        return UniquePathsWithMemo(m, n, memo);
    }

    private int UniquePathsWithMemo(int m, int n, Dictionary<(int, int), int> memo)
    {
        var key = (m, n);
        if (memo.ContainsKey(key))
            return memo[key];

        if (m < 0 || n < 0)
            return 0;

        var res = UniquePathsWithMemo(m - 1, n, memo) + UniquePathsWithMemo(m, n - 1, memo);
        memo[key] = res;
        return res;
    }
}

public class UniquePathsCalculatorRecursive : IUniquePathsCalculator
{
    public int UniquePaths(int m, int n)
    {
        if (m == 1 && n == 1)
            return 1;

        if (m < 0 || n < 0)
            return 0;

        return UniquePaths(m - 1, n) + UniquePaths(m, n - 1);
    }
}