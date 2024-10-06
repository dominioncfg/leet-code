public interface ILongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums);
}

public class LongestConsecutiveSequence : ILongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums)
    {
        var dict = new HashSet<int>(nums);

        var longestSecuenceLength = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            var currentValue = nums[i];
            var isPartOfAnotherChain = dict.Contains(currentValue - 1);

            if (isPartOfAnotherChain)
                continue;

            var currentChain = 1;
            var j = currentValue + 1;
            while (dict.Contains(j))
            {
                j++;
                currentChain++;
            }

            if (currentChain > longestSecuenceLength)
                longestSecuenceLength = currentChain;

        }

        return longestSecuenceLength;
    }
}
