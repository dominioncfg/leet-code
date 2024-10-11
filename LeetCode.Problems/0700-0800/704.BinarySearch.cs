public interface IBinarySearch
{
    public int Search(int[] nums, int target);
}

public class BinarySearch : IBinarySearch
{
    public int Search(int[] nums, int target)
    {
        var lowLimit = 0;
        var upperLimit = nums.Length - 1;
        var mid = int.MaxValue;

        bool ended = false;
        while (upperLimit >= lowLimit)
        {
            mid = (lowLimit + upperLimit) / 2;

            var current = nums[mid];

            if (current == target)
                return mid;

            if (current > target)
            {
                upperLimit = mid - 1;
            }
            else
            {
                lowLimit = mid + 1;
            }
        }


        return -1;
    }
}
