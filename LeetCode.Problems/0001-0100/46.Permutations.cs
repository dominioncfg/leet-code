
public interface IPermutations
{
    public IList<IList<int>> Permute(int[] nums);
}

public class PermutationsRecursive : IPermutations
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        BackTrack(nums, ref result, []);
        return result;
    }

    public void BackTrack(int[] nums, ref List<IList<int>> res, HashSet<int> sol)
    {
        var n = nums.Length;

        if(sol.Count == n)
        {
            res.Add(new List<int>(sol));
            return;
        }

        foreach (var num in nums)
        {
            if(sol.Contains(num))
                continue;

            sol.Add(num);
            BackTrack(nums, ref res, sol);

            sol.Remove(num);
        }
    }
}


