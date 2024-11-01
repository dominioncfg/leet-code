public interface ILongestIncreasingSubsequence
{
    public int LengthOfLIS(int[] nums);
}

public class LongestIncreasingSubsequence : ILongestIncreasingSubsequence
{
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        var globalMax = 1;

        for (int currentInvestigateIndex = 1; currentInvestigateIndex < nums.Length; currentInvestigateIndex++)
        {
            var currentInvestigateValue = nums[currentInvestigateIndex];
            for (var alreadyCalculateIndex = 0; alreadyCalculateIndex < currentInvestigateIndex; alreadyCalculateIndex++)
            {
                var compareToValue = nums[alreadyCalculateIndex];

                if (currentInvestigateValue <= compareToValue)
                    continue;

                dp[currentInvestigateIndex] = Math.Max(dp[currentInvestigateIndex], dp[alreadyCalculateIndex] + 1);

            }

            if (dp[currentInvestigateIndex] > globalMax)
                globalMax = dp[currentInvestigateIndex];

        }

        return globalMax;
    }
}

