
public interface IClimbingStairs
{
    public int ClimbStairs(int n);
}

public class ClimbingStairsIterative : IClimbingStairs
{
    public int ClimbStairs(int n)
    {
        if (n == 1)
            return 1;

        var previous = 1; 
        var current = 2;


        for (int i = 2; i < n; i++)
        {
            var next = previous + current;
            previous = current;
            current = next;
        }


        return current;
    }
}

public class ClimbingStairsRecursive : IClimbingStairs
{
    public int ClimbStairs(int n)
    {
        if(n == 1)
            return 1;
        if(n == 2) return 2;

        return ClimbStairs(n-1) + ClimbStairs(n-2);
    }
}

