public interface IMaxConsecutiveOnesIII

{
    public int LongestOnes(int[] nums, int k);
}

public class MaxConsecutiveOnesIIISlidingWindow : IMaxConsecutiveOnesIII
{
    public int LongestOnes(int[] nums, int k)
    {
        var maximumLength = 0;
        var zeros = 0;
        var l = 0;

        for (int i = 0; i < nums.Length; i++)
        {

            if (nums[i] == 0)
                zeros++;


            while (zeros > k)
            {
                if (nums[l] == 0)
                {
                    zeros--;
                }
                l++;
            }

            maximumLength = Math.Max(maximumLength, i - l + 1);

        }

        return maximumLength;
    }
}

public class MaxConsecutiveOnesIIIBruteForceSolution : IMaxConsecutiveOnesIII
{
    public int LongestOnes(int[] nums, int k)
    {
        var result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var currentZeroRemainings = k;

            var currentChain = 0;
            for (int j = i; j < nums.Length; j++)
            {
                if (nums[j] == 0 && currentZeroRemainings == 0)
                    break;

                if (nums[j] == 0)
                    currentZeroRemainings--;

                currentChain++;
            }
            if (currentChain > result)
                result = currentChain;
        }

        return result;
    }
}

