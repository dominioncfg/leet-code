

public interface INetworkDelayTimeCalculator
{
    public int NetworkDelayTime(int[][] times, int n, int k);
}

public class NetworkDelayTimeCalculator : INetworkDelayTimeCalculator
{
    private const int InvalidSolution = -1;
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var adjacencyList = BuildAdjacencyList(times, n);

        var visitedNodes = new HashSet<int>();
        var minPathsToNodes = new PriorityQueue<int, int>();

        minPathsToNodes.Enqueue(k,0);



        var maxDistance = 0;
        while (minPathsToNodes.Count > 0)
        {
            minPathsToNodes.TryDequeue(out var node, out var w);

            if (visitedNodes.Contains(node))
                continue;

            visitedNodes.Add(node);

            if (w>maxDistance)
                maxDistance = w;


            var nodeEdges = adjacencyList[node] ?? new List<(int NodeTo, int Weight)>();

            foreach (var item in nodeEdges)
            {
                var weightFromRoot = w + item.Weight;
                minPathsToNodes.Enqueue(item.NodeTo, weightFromRoot);
            }
        }


        return visitedNodes.Count == n ? maxDistance : InvalidSolution;
    }




    private List<(int NodeTo, int Weight)>[] BuildAdjacencyList(int[][] edges, int numberOfNodes)
    {
        var nodes = new List<(int NodeTo, int Weight)>[numberOfNodes + 1];

        foreach (var edge in edges)
        {
            var source = edge[0];
            var destination = edge[1];
            var w = edge[2];

            if (nodes[source] is null)
                nodes[source] = new List<(int NodeTo, int Weight)>();

            nodes[source].Add((destination, w));
        }

        return nodes;
    }
}
