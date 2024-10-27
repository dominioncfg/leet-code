
public interface ICombinationSumCalculator
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target);
}


public class CombinationSumCalculator1 : ICombinationSumCalculator
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        BackTrack(candidates, target, ref result, [], 0, 0, 0);
        return result;
    }


    public void BackTrack(int[] candidates, int target, ref List<IList<int>> res, List<int> sol, int takenCount, int sumSoFar, int startLookupFrom)
    {
        if (sumSoFar == target)
        {
            res.Add(new List<int>(sol));
            return;
        }
        if (takenCount == target || sumSoFar > target)
        {
            return;
        }

        for (int lookupStart = startLookupFrom; lookupStart < candidates.Length; lookupStart++)
        {
            int candidate = candidates[lookupStart];
            sol.Add(candidate);
            BackTrack(candidates, target, ref res, sol, takenCount + 1, sumSoFar + candidate, lookupStart);
            sol.RemoveAt(sol.Count - 1);
        }
    }
}

public class CombinationSumCalculator : ICombinationSumCalculator
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        BackTrack(candidates, target, result, [], 0, 0);
        return result;
    }


    public void BackTrack(int[] candidates, int target, List<IList<int>> res, List<int> sol, int sumSoFar, int current)
    {
        if (sumSoFar == target)
        {
            res.Add(new List<int>(sol));
            return;
        }
        if (sumSoFar > target || current ==  candidates.Length)
        {
            return;
        }

        BackTrack(candidates, target, res, sol, sumSoFar, current + 1);

        sol.Add(candidates[current]);
        BackTrack(candidates, target, res, sol, sumSoFar + candidates[current], current);
        sol.RemoveAt(sol.Count - 1);
    }


}