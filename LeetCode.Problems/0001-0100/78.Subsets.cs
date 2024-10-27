
public interface IAllSubsets
{
    public IList<IList<int>> Subsets(int[] nums);
}


public class AllSubsetsIterative : IAllSubsets
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        res.Add(new List<int>(new List<int>()));

        foreach (int num in nums)
        {
            List<IList<int>> curr = new List<IList<int>>(res);

            foreach (IList<int> r in res)
            {
                List<int> ls = new List<int>(r);
                ls.Add(num);
                curr.Add(ls);
            }
            res = curr;
        }

        return res;
    }

   
}

public class AllSubsetsRecursive : IAllSubsets
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        BackTrack(nums, ref result, new List<int>(), 0);

        return result;
    }


    public void BackTrack(int[] nums, ref List<IList<int>> res, List<int> sol, int i)
    {
        var n = nums.Length;

        if(i==n)
        {
            res.Add(new List<int>(sol));
            return;
        }
        BackTrack(nums, ref res, sol, i + 1);

        sol.Add(nums[i]);
        BackTrack(nums, ref res, sol, i + 1);
        sol.RemoveAt(sol.Count - 1);
    }

}


