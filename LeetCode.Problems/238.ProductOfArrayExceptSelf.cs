public interface IProductOfArrayExceptSelf

{
    public int[] ProductExceptSelf(int[] nums);
}

public class ProductOfArrayExceptSelfWithTwoArrays : IProductOfArrayExceptSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var left = new int[nums.Length];
        left[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            left[i] = nums[i - 1] * left[i - 1];
        }

        var right = new int[nums.Length];
        right[right.Length - 1] = 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            right[i] = nums[i + 1] * right[i + 1];
        }

        var result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = left[i] * right[i];
        }

        return result;
    }
}


public class ProductOfArrayExceptSelfWithOneArray : IProductOfArrayExceptSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var left = new int[nums.Length];
        left[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            left[i] = nums[i - 1] * left[i - 1];
        }

        var right = nums[nums.Length -1];
        

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            left[i] = left[i] * right;
            right *= nums[i];
        }

        return left;
    }
}