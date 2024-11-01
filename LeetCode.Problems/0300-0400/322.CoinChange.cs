public interface ICoinChanger
{
    public int CoinChange(int[] coins, int amount);
}

public class CoinChangerDpBottomUpTabulation : ICoinChanger
{
    const int InvalidResponse = -1;
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
            return 0;

        if (coins.Length == 0)
            return -1;

        Array.Sort(coins);

        var dp = new int?[amount + 1];
        dp[0] = 0;

        for (int amountToCalculate = 1; amountToCalculate < dp.Length; amountToCalculate++)
        {
            int? minCointAtPosition = null;
            for (var cointToCheck = 0; cointToCheck < coins.Length; cointToCheck++)
            {
                var currentCoin = coins[cointToCheck];
                var diff = amountToCalculate - currentCoin;

                if (diff < 0)
                    break;

                var coinsUsed = dp[diff] + 1;

                if (coinsUsed is null)
                    continue;

                if (minCointAtPosition is null)
                    minCointAtPosition = coinsUsed;
                else
                    minCointAtPosition = Math.Min(minCointAtPosition.Value, coinsUsed.Value);
            }
            dp[amountToCalculate] = minCointAtPosition;
        }

        return dp[amount] ?? InvalidResponse;
    }
}

public class CoinChangerTopDownMemo : ICoinChanger
{
    const int InvalidResponse = -1;
    public int CoinChange(int[] coins, int amount)
    {
        Array.Sort(coins);
        var memo = new Dictionary<int, int?>()
        {
            [0] = 0,
        };
        var result = CoinChangeWithMemo(coins, amount, memo);
        return result ?? InvalidResponse;
    }

    public int? CoinChangeWithMemo(int[] coins, int amount, Dictionary<int,int?> memo)
    {
        if(memo.ContainsKey(amount))
            return memo[amount];

        int? max = null;
        foreach (var coin in coins)
        {
            var diff = amount - coin;
            if (diff < 0)
                break;

            var distribution = CoinChangeWithMemo(coins, diff, memo);

            if (distribution is null)
                continue;

            var coinsUsed = distribution.Value + 1;

            if (max is null)
                max = coinsUsed;
            else
                max = Math.Min(max.Value, coinsUsed);
        }
        memo[amount] = max;

        return max;
    }
}




