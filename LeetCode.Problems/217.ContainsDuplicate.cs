public interface IContainsDuplicate
{
    public bool ContainsDuplicate(int[] nums);
}

public class ContainsDuplicateCalculator : IContainsDuplicate
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        foreach (int i in nums)
        {
            if (!set.Add(i))
            {
                return true;
            }
        }
        return false;
    }   
}
