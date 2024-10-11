
using System.Security.Cryptography;

public interface ISearchInsertPosition
{
    public int SearchInsert(int[] nums, int target);
}

public class SearchInsertPosition : ISearchInsertPosition
{
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;


        var middle = 0;
        while (left <= right)
        {
            middle = (left + right) / 2;
            var current = nums[middle];

            if (current == target)
                return middle;
            else if (current > target)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return target > nums[middle] ? middle + 1  : middle;
    }
}

