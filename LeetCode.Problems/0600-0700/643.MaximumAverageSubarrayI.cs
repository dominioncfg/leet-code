public interface IMaximumAverageSubarrayI
{
    public double FindMaxAverage(int[] nums, int k);
}

public class MaximumAverageSubarrayI : IMaximumAverageSubarrayI
{
    public double FindMaxAverage(int[] nums, int k)
    {
        var maxSum = double.MinValue;
        var maxInteger = 0;

        var currentSum = 0d;
        var currentCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {

            if (currentCount == k)
            {
                currentSum -= nums[i - k];
            }
            else
            {
                currentCount++;
            }
            currentSum += nums[i];

            if (currentSum >= maxSum || maxInteger < k)
            {
                maxSum = currentSum;
                maxInteger = currentCount;
            }
        }

        return maxSum / maxInteger;
    }
}