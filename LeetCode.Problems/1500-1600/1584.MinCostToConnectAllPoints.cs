
public interface IMinCostToConnectAllPoints
{
    public int MinCostConnectPoints(int[][] points);
}

public class MinCostToConnectAllPoints : IMinCostToConnectAllPoints
{
    public int MinCostConnectPoints(int[][] points)
    {
        var visitedNodes = new HashSet<int[]>(points.Length);
        var distanceSoFar = new PriorityQueue<int[], int>();

        visitedNodes.Add(points[0]);
        FillDistancesFromPoint(points[0], points, visitedNodes, distanceSoFar);
        var totalDistance = 0;
       

        while (visitedNodes.Count < points.Length)
        {
            while (true)
            {
                int[] point;
                distanceSoFar.TryDequeue(out point!, out int distance);

                if (visitedNodes.Contains(point))
                    continue;

                visitedNodes.Add(point);
                totalDistance += distance;
                FillDistancesFromPoint(point, points, visitedNodes, distanceSoFar);
                break;
            }
        }


        return totalDistance;
    }

    private void FillDistancesFromPoint(int[] point, int[][] points, HashSet<int[]> visitedNodes, PriorityQueue<int[], int> storedDistances)
    {
        for (int anotherPointIndex = 0; anotherPointIndex < points.Length; anotherPointIndex++)
        {
            var anotherPoint = points[anotherPointIndex];
            if (visitedNodes.Contains(anotherPoint))
                continue;
           
            var distance = ManhattanDistance(point, anotherPoint);

            storedDistances.Enqueue(anotherPoint, distance);
        }

    }

    private int ManhattanDistance(int[] point1, int[] point2)
    {
        return Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);
    }
}
