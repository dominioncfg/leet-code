public interface IHouseRobber
{
    public int Rob(int[] nums);
}

public class HouseRobber : IHouseRobber
{
    public int Rob(int[] nums)
    {
        if (nums.Length ==  1)
            return nums[0];

        var prev = nums[0];
        var curr = Math.Max(nums[1], nums[0]);

        for (int i = 2; i < nums.Length; i++)
        {
            var next = Math.Max(nums[i] + prev, curr);
            prev = curr;
            curr = next;
        }

        return Math.Max(prev, curr);
    }

}

public class HouseRobberRecursive : IHouseRobber
{
    public int Rob(int[] nums)
    {
        return RobThis(nums, nums.Length -1);
    }

    public int RobThis(int[] nums, int ind)
    {
        if (ind < 0) 
            return 0;

        return Math.Max(nums[ind] + RobThis(nums,ind -2), RobThis(nums,ind -1));
    }
}

