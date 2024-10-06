public interface IMajorityElementCalculator
{
    public int MajorityElement(int[] nums);
}

public class MajorityElementCalculator : IMajorityElementCalculator
{
    public int MajorityElement(int[] nums)
    {
        var majority = Math.Ceiling((double)nums.Length / 2);
        var foundsSoFar = new Dictionary<int, int>();

        foreach (var integer in nums)
        {
            if (foundsSoFar.ContainsKey(integer))
                foundsSoFar[integer]++;
            else foundsSoFar[integer] = 1;

            if (foundsSoFar[integer] == majority)
                return integer;
        }

        return 0;
    }
}

public class MajorityElementCalculatorNoDictionary : IMajorityElementCalculator
{
    public int MajorityElement(int[] nums)
    {
        int count = 0;
        int element = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (count == 0)
            {
                count = 1;
                element = nums[i];
            }
            else if (element == nums[i])
            {
                count++;
            }
            else
            {
                count--;
            }
        }
        return element;
    }
}