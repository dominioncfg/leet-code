
public interface ISearchInRotatedSortedArray
{
    public int Search(int[] nums, int target);
}

public class SearchInRotatedSortedArray : ISearchInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;
        var minIndex = FindMin(nums);


        var l = 0;
        var r = nums.Length - 1;

        var minIndexValue = nums[minIndex];

        if (minIndex > 0)
        {
            if (target >= nums[0] && target <= nums[minIndex - 1])
            {
                r = minIndex - 1;
            }
            else
            {
                l = minIndex;
            }
        }


        while (l <= r)
        {
            var m = (l + r) / 2;


            var current = nums[m];

            if (current == target)
                return m;



            if (current > target)
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;

            }
        }


        return -1;
    }


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


        return l;
    }
}

