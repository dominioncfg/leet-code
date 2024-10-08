public interface ITwoSum2InputArrayIsSorted
{
    public int[] TwoSum(int[] numbers, int target);
}

public class TwoSum2InputArrayIsSorted : ITwoSum2InputArrayIsSorted
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var leftIndex = 0;
        var rightIndex = numbers.Length - 1;

        while (leftIndex < rightIndex)
        {
            var left = numbers[leftIndex];
            var right = numbers[rightIndex];

            var sum = left + right;

            if (sum == target)
                return [leftIndex + 1, rightIndex + 1];

            if (sum > target)
            {
                rightIndex--;
            }
            else
            {
                leftIndex++;
            }

        }

        throw new ArgumentException($"No two numbers in the array can be added to obtain target. {target}");
    }
}

