
public interface ICombinations
{
    public IList<IList<int>> Combine(int n, int k);
}


public class CombinationsIterative : ICombinations
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var ret = new List<IList<int>>();
        var buf = new List<int>(k);

        for (int i = 1; i <= k; i++)
        {
            buf.Add(i);
        }
        ret.Add(buf.ToArray());


        int pos = buf.Count - 1;
        while (pos >= 0)
        {
            if (buf[pos] >= n)
            {
                pos--;
                continue;
            }

            buf[pos]++;

            if (pos < k - 1)
            {
                buf[pos + 1] = buf[pos];
                pos++;
                continue;
            }
            ret.Add(buf.ToArray());
        }

        return ret;
    }

}

public class CombinationsRecursive : ICombinations
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        BackTrack(n, k, ref result, [], 1);
        return result;
    }


    public void BackTrack(int n, int k, ref List<IList<int>> res, HashSet<int> sol, int j)
    {
        if (sol.Count == k)
        {
            res.Add(new List<int>(sol));
            return;
        }

        for (int i = j; i <= n; i++)
        {
            if (sol.Contains(i))
                continue;

            sol.Add(i);
            BackTrack(n, k, ref res, sol,i+1);
            sol.Remove(i);
        }
    }

}


