
public interface IMaxSubarray
{
    public int MaxSubArray(int[] nums);
}

public class MaxSubarray : IMaxSubarray
{
    List<string> result = new List<string>();

    public int MaxSubArray(int[] nums)
    {
        var localMax = 0;
        var globalMax = int.MinValue;


        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            localMax = localMax + num;

            globalMax =  Math.Max(localMax, globalMax);

            if(localMax < 0)
                localMax = 0;

        }

        return globalMax;
    }



}
