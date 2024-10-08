public interface ITrapRainWaterCalculator
{
    public int Trap(int[] height);
}

public class TrapRainWaterCalculator : ITrapRainWaterCalculator
{
    public int Trap(int[] height)
    {
        var maxsLeft = new int[height.Length];
        var maxsRights = new int[height.Length];

        var maxLeftSoFar = 0;
        var maxRightSoFar = 0;


        for (int i = 0; i < height.Length; i++)
        {
            var j = height.Length - 1 - i;
            maxsLeft[i] = maxLeftSoFar;
            maxsRights[j] = maxRightSoFar;
            
            maxLeftSoFar  = Math.Max(maxLeftSoFar, height[i]);
            maxRightSoFar = Math.Max(maxRightSoFar, height[j]);
        }

        var sum = 0;
        for (int i = 0; i < height.Length; i++)
        {
            var min = Math.Min(maxsLeft[i], maxsRights[i]);
            var realWater = Math.Max(min - height[i],0);
            sum += realWater;
        }

        return sum;
    }
}