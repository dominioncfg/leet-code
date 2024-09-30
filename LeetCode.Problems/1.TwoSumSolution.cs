public interface ITwoSumSolution
{
    public int[] TwoSum(int[] nums, int target);
}

public class TwoSumBruteForceSolution : ITwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }
        throw new Exception("No Solution Available");
    }
}


public class TwoSumLinearSolution : ITwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            dictionary[nums[i]] = i;
        }


        for (int potentialSolution1Index = 0; potentialSolution1Index < nums.Length; potentialSolution1Index++)
        {
            var potentialSolution1Value = nums[potentialSolution1Index];
            var potentialSolution2Value = target - potentialSolution1Value;
            if (dictionary.TryGetValue(potentialSolution2Value, out int potentialSolution2Index) && potentialSolution1Index!= potentialSolution2Index)
                return [potentialSolution1Index, potentialSolution2Index];
        }

        throw new Exception("No Solution Available");
    }
}



public class TwoSumLinearAsWeGoSolution : ITwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (int potentialSolution2Index = 0; potentialSolution2Index < nums.Length; potentialSolution2Index++)
        {
            var potentialSolution2Value = nums[potentialSolution2Index];
            var potentialSolution1Value = target - potentialSolution2Value;
            
            if (dictionary.TryGetValue(potentialSolution1Value, out int potentialSolution1Index))
                return [potentialSolution1Index, potentialSolution2Index];

            dictionary.TryAdd(potentialSolution2Value, potentialSolution2Index);
        }


        throw new Exception("No Solution Available");
    }
}