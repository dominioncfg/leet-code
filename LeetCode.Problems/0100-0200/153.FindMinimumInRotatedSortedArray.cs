public interface IFindMinimumInRotatedSortedArray
{
    public int FindMin(int[] nums);
}

public class FindMinimumInRotatedSortedArray : IFindMinimumInRotatedSortedArray
{
    public int FindMin(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l < r)
        {
            var m = (l + r) / 2;

            var current = nums[m];
            var rValue = nums[r];

            if (current > rValue)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }


        return nums[l];
    }
}

