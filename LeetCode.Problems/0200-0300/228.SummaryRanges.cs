
public interface ISummaryRangesCalculator
{
    public IList<string> SummaryRanges(int[] nums);
}

public class SummaryRangesCalculator : ISummaryRangesCalculator
{
    public IList<string> SummaryRanges(int[] nums)
    {
        List<string> result = new List<string>();

        int?[]? curentRange = null;
        for (int i = 0; i < nums.Length; i++)
        {
            var current = nums[i];

            if (curentRange is null)
            {
                curentRange = new int?[2];
                curentRange[0] = nums[i];
                continue;
            }
            if (nums[i] > nums[i-1] + 1)
            {
                WriteRange(curentRange, result);
                curentRange = new int?[2];
                curentRange[0] = nums[i];
            }
            else
            {
                curentRange[1] = nums[i];
            }
        }
        WriteRange(curentRange, result);
        return result;
    }

    private void WriteRange(int?[]? curentRange, List<string> result)
    {
        if (curentRange is null)
            return;

        if (curentRange[1].HasValue)
            result.Add($"{curentRange[0]}->{curentRange[1]}");
        else
            result.Add(($"{curentRange[0]}"));
    }
}


public class SummaryRangesSlidingWindowCalculator : ISummaryRangesCalculator
{
    public IList<string> SummaryRanges(int[] nums)
    {

        List<string> ranges = new();
        int maxLength = nums.Length;

        for (int i = 0; i < maxLength;)
        {
            int currentValue = nums[i];
            int k = 1;

            while (i + k < maxLength && nums[i + k] - k == currentValue)
            {
                k++;
            }

            if (k == 1)
            {
                ranges.Add(currentValue.ToString());
            }
            else
            {
                ranges.Add($"{currentValue}->{nums[i + k - 1]}");
            }

            i += k;
        }

        return ranges;
    }
}
