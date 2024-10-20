public interface IKClosestPointsToOrigin
{
    public int[][] KClosest(int[][] points, int k);
}

public class KClosestPointsToOrigin : IKClosestPointsToOrigin
{
    public int[][] KClosest(int[][] points, int k)
    {
        var closestToOrigin = new PriorityQueue<int[], int>(k, Comparer<int>.Create((a, b) => b - a));

        foreach (var pair in points)
        {
            var x = pair[0];
            var y = pair[1];

            var distanceToOrigin = x*x + y*y;

            if(closestToOrigin.Count<k)
            {
                closestToOrigin.Enqueue(pair,distanceToOrigin);
            }
            else
            {
                closestToOrigin.TryPeek(out var element, out var maxOfMinSoFar);

                if (maxOfMinSoFar > distanceToOrigin)
                {
                    closestToOrigin.EnqueueDequeue(pair,distanceToOrigin);
                }
            }
        }

        var result = new int[k][];

        while(closestToOrigin.Count>0)
        {
            result[k-1] = closestToOrigin.Dequeue();
            k--;
        }

        return result;
    }
}
