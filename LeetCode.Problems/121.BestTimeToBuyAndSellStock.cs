public interface IBestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices);
}

public class BestTimeToBuyAndSellStockGreedy : IBestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = int.MinValue;
        for (int i = 0; i < prices.Length; i++)
        {
            var buy = prices[i];

            for (int j = i; j < prices.Length; j++)
            {
                var sell = prices[j];
                
                var profit = sell - buy;
                
                if (profit> maxProfit)
                    maxProfit = profit;

            }
        }
        return maxProfit > 0 ? maxProfit : 0;
    }
}

public class BestTimeToBuyAndSellStockNTimeSolution : IBestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var betterBuyPriceSoFar = prices[0];

        for (int i = 0; i < prices.Length; i++)
        {
            var buy = prices[i];
           
            if (buy < betterBuyPriceSoFar)
                betterBuyPriceSoFar = buy;
            else
            {
                var profit = buy - betterBuyPriceSoFar;
                maxProfit = Math.Max(maxProfit, profit);
            }
        }
        return maxProfit;
    }
}
