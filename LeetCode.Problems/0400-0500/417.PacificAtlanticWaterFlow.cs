

public interface IPacificAtlanticWaterFlow
{
    public IList<IList<int>> PacificAtlantic(int[][] heights);
}

public class PacificAtlanticWaterFlow : IPacificAtlanticWaterFlow
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var pQueue = new Queue<(int, int)>();
        var pSeen = new HashSet<(int, int)>();
        var aQueue = new Queue<(int, int)>();
        var aSeen = new HashSet<(int, int)>();

        EnqueueInitialPacificCoordinates(heights, pQueue, pSeen);
        EnqueueInitialAtlanticCoordinates(heights, aQueue, aSeen);

        var positionsThatLeadToThePacific = TraverseWaterFlowTree(heights, pQueue, pSeen);
        var positionsThatLeadToTheAtlantic = TraverseWaterFlowTree(heights, aQueue, aSeen);

        var intersection = IntersectHashSets(positionsThatLeadToThePacific, positionsThatLeadToTheAtlantic);

        return intersection;
    }

    private void EnqueueInitialPacificCoordinates(int[][] heights, Queue<(int, int)> pQueue, HashSet<(int, int)> pSeen)
    {
        var m = heights.Length;
        var n = heights[0].Length;
        for (int i = 0; i < m; i++)
        {
            pQueue.Enqueue((i, 0));
            pSeen.Add((i, 0));
        }

        for (int i = 1; i < n; i++)
        {
            pQueue.Enqueue((0, i));
            pSeen.Add((0, i));
        }
    }

    private void EnqueueInitialAtlanticCoordinates(int[][] heights, Queue<(int, int)> aQueue, HashSet<(int, int)> aSeen)
    {
        var m = heights.Length;
        var n = heights[0].Length;
        for (int i = 0; i < m; i++)
        {
            aQueue.Enqueue((i, n - 1));
            aSeen.Add((i, n - 1));
        }

        for (int i = 0; i < n - 1; i++)
        {
            aQueue.Enqueue((m - 1, i));
            aSeen.Add((m - 1, i));
        }
    }

    private HashSet<(int, int)> TraverseWaterFlowTree(int[][] heights, Queue<(int X, int Y)> queue, HashSet<(int, int)> seen)
    {
        var result = new HashSet<(int, int)>();
        var m = heights.Length;
        var n = heights[0].Length;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            var collidingPosition = (List<(int, int)>)[(-1, 0), (1, 0), (0, -1), (0, 1)];
            result.Add(node);

            if (node.X == 4 && node.Y == 0)
            {

            }

            foreach (var item in collidingPosition)
            {
                var position = (node.X + item.Item1, node.Y + item.Item2);

                if (position.Item1 < 0 || position.Item1 >= m)
                    continue;

                if (position.Item2 < 0 || position.Item2 >= n)
                    continue;

                if (seen.Contains(position))
                    continue;

                if (heights[node.X][node.Y] > heights[position.Item1][position.Item2])
                    continue;

                seen.Add(position);
                queue.Enqueue(position);
            }


        }
        return result;
    }

    private static List<IList<int>> IntersectHashSets(HashSet<(int X, int Y)> a, HashSet<(int X, int Y)> b)
    {
        var intersection = new List<IList<int>>();
        var added = new HashSet<(int,int)>();
        foreach (var item in a)
        {
            if (b.Contains(item))
            {
                intersection.Add([item.X,item.Y]);
                added.Add(item);
            }

        }

        foreach (var item in b)
        {
            if (a.Contains(item) && !added.Contains(item))
            {
                intersection.Add([item.X, item.Y]);
            }
        }
      
        return intersection;
    }
}
