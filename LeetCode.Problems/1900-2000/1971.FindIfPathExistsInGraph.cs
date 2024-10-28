using System.Xml.Linq;

public interface IFindIfPathExistsInGraph
{
    public bool ValidPath(int n, int[][] edges, int source, int destination);
}

public class FindIfPathExistsInGraphAdjacencyList : IFindIfPathExistsInGraph
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
            return true;

        var adjacencyList = BuildAdjecencyList(n, edges);

        var pathExist = ExistPathBetweenNodes(adjacencyList, source, destination);

        return pathExist;
    }

    private List<List<int>> BuildAdjecencyList(int n, int[][] edges)
    {
        var result = new List<List<int>>(n);

        for (int i = 0; i < n; i++)
        {
            result.Add([]);
        }

        foreach (var edge in edges)
        {
            var source = edge[0];
            var destination = edge[1];

            result[source].Add(destination);
            result[destination].Add(source);
        }

        return result;
    }


    private bool ExistPathBetweenNodes(List<List<int>> edges, int source, int destination)
    {
        var seenNodes = new HashSet<int>();
        var nodesToVisit = new Stack<int>();

        nodesToVisit.Push(source);
        seenNodes.Add(source);

        while (nodesToVisit.Count > 0)
        {
            var node = nodesToVisit.Pop();
            
            var adjacencyNodes = edges[node];

            foreach (var destinationNodeOfEdge in adjacencyNodes)
            {
                if (destinationNodeOfEdge == destination)
                    return true;

                if (!seenNodes.Contains(destinationNodeOfEdge))
                {
                    seenNodes.Add(destinationNodeOfEdge);
                    nodesToVisit.Push(destinationNodeOfEdge);
                }

            }
        }
        return false;
    }
}

public class FindIfPathExistsInGraphAdjacencyMatrix : IFindIfPathExistsInGraph
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
            return true;

        var adjacencyMatrix = BuildMatrix(n, edges);

        var pathExist = ExistPathBetweenNodes(adjacencyMatrix, source, destination);

        return pathExist;
    }

    private bool[][] BuildMatrix(int n, int[][] edges)
    {
        var result = new bool[n][];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new bool[n];
        }

        foreach (var edge in edges)
        {
            var source = edge[0];
            var destination = edge[1];

            result[source][destination] = true;
            result[destination][source] = true;
        }

        return result;
    }


    private bool ExistPathBetweenNodes(bool[][] adjacencyMatrix, int source, int destination)
    {


        var visitedNodes = new HashSet<int>();
        var nodesToVisit = new Queue<int>();

        nodesToVisit.Enqueue(source);

        while (nodesToVisit.Count > 0)
        {
            var node = nodesToVisit.Dequeue();
            visitedNodes.Add(node);
            var adjacencyNodes = adjacencyMatrix[node];

            for (int destinationNodeOfEdge = 0; destinationNodeOfEdge < adjacencyNodes.Length; destinationNodeOfEdge++)
            {
                bool edgeIsConnected = adjacencyNodes[destinationNodeOfEdge];
                if (!edgeIsConnected)
                    continue;

                if (destinationNodeOfEdge == destination)
                    return true;

                if (!visitedNodes.Contains(destinationNodeOfEdge))
                    nodesToVisit.Enqueue(destinationNodeOfEdge);
            }

        }
        return false;
    }
}
