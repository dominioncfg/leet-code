
public interface IJumpGame
{
    public bool CanJump(int[] nums);
}

public class JumpGameIterative : IJumpGame
{
    public bool CanJump(int[] nums)
    {
        if (nums.Length == 1)
            return true;

        var currentNeedToJumpIndex = nums.Length - 1;


        for (int i = nums.Length - 2; i >= 0; i--)
        {
            var value = nums[i];

            if(i + value>= currentNeedToJumpIndex)
                currentNeedToJumpIndex = i;

        }

        return currentNeedToJumpIndex == 0;
    }

}


public class JumpGameRecursive : IJumpGame
{
    public bool CanJump(int[] nums)
    {
        return CanJumpRecursive(nums,0, []);
    }

    private static bool CanJumpRecursive(int[] nums, int currentPosition, HashSet<int> falsePostions)
    {
        if (currentPosition == nums.Length - 1)
            return true;

        if (falsePostions.Contains(currentPosition))
            return false;

        var value = nums[currentPosition];

        for (int canJumpTo = 1; canJumpTo < value + 1; canJumpTo++)
        {
            if (CanJumpRecursive(nums, currentPosition + canJumpTo, falsePostions))
                return true;
        }

        falsePostions.Add(currentPosition);
        return false;
    }
}