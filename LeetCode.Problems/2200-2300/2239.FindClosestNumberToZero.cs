public interface INumClosestToZero
{
    int FindClosestNumber(int[] nums);
}

public class NumClosestToZero : INumClosestToZero
{
    public int FindClosestNumber(int[] nums)
    {
        if (nums.Length == 0)
            throw new InvalidOperationException("No Numbers");
        
        var closest = nums[0];
        var closedMod = Math.Abs(closest);

        foreach (int num in nums)
        {
            var numMod = Math.Abs(num);
            if (numMod == closedMod)
            {
                closest = Math.Max(num, closest);
            }
            else if (numMod < closedMod)
            {
                closest = num;
                closedMod = numMod;
            }
        }

        return closest;
    }
}
