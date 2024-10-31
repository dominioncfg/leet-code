public interface IMinimumCostClimbingStairs
{
    public int MinCostClimbingStairs(int[] cost);
}

public class MinimumCostClimbingStairs : IMinimumCostClimbingStairs
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var prev = 0;
        var curr = 0;

        for (int i = 2; i <= cost.Length; i++)
        {
            var next = Math.Min(cost[i - 2] + prev, cost[i - 1] + curr);
            prev = curr;
            curr = next;
        }
        return curr;
    }

}

public class MinimumCostClimbingStairsRecursive : IMinimumCostClimbingStairs
{
    public int MinCostClimbingStairs(int[] cost)
    {
        return CalcMinCostClimbingStairs(cost, cost.Length);
    }

    public int CalcMinCostClimbingStairs(int[] cost, int step)
    {
        if (step < 2)
            return 0;

        var costOnThisStep = 0;

        if (step >= cost.Length)
            costOnThisStep = 0;
        else costOnThisStep = cost[step];

        var costStep1 = cost[step - 1] + CalcMinCostClimbingStairs(cost, step - 1);
        var costStep2 = cost[step - 2] + CalcMinCostClimbingStairs(cost, step - 2);

        return Math.Min(costStep1, costStep2);
    }
}
