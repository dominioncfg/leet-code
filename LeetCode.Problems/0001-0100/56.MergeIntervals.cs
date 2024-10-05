
public interface IMergeIntervals
{
    public int[][] Merge(int[][] intervals);
}

public class MergeIntervals : IMergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        var sorterIntervals = intervals
             .OrderBy(x => x[0]).ToList()
             .ToArray();

        var result = new List<int[]>();

        int[] currentRange = sorterIntervals[0];
        for (int i = 1; i < sorterIntervals.Length; i++)
        {
            var rangeToMergeIfPossible = sorterIntervals[i];
            var smallerEnd = currentRange[1];
            var biggerStart = rangeToMergeIfPossible[0];
            var collide = smallerEnd >= biggerStart;
            if (collide)
            {
                currentRange[0] = Math.Min(currentRange[0], rangeToMergeIfPossible[0]);
                currentRange[1] = Math.Max(currentRange[1], rangeToMergeIfPossible[1]);
            }
            else
            {
                result.Add(currentRange);
                currentRange = rangeToMergeIfPossible;
            }
        }

        result.Add(currentRange);

        return result.ToArray();
    }
   
}
