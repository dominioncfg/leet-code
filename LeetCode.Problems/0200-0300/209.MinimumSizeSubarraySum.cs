public interface IMinimumSizeSubarraySum
{
    public int MinSubArrayLen(int target, int[] nums);
}


public class MinimumSizeSubarraySum : IMinimumSizeSubarraySum
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var minLength = (int?)null;

        var l = 0;

        var currentSum = 0;

        for (int r = 0; r < nums.Length; r++)
        {
            currentSum += nums[r];

            if (currentSum >= target)
            {
                while (currentSum >= target)
                {
                    var possibleMinLenght = r - l + 1;
                    minLength = Math.Min(minLength ?? int.MaxValue, possibleMinLenght);

                    currentSum -= nums[l];
                    l++;
                }
            }
        }
        return minLength ?? 0;
    }
}
