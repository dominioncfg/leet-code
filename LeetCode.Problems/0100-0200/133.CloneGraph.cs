using Node = IGraphsClonner.Node;

public interface IGraphsClonner
{
    public Node? CloneGraph(Node? node);

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
public class GraphsClonnerIterative : IGraphsClonner
{
    public Node? CloneGraph(Node? node)
    {
       if(node == null) return node;

        var visited = new HashSet<int>();
        var createds = new Dictionary<int, Node>();
        var staco = new Stack<Node>();
        Node newNode = null;

        staco.Push(node);
        while (staco.Count > 0)
        {
            var current = staco.Pop();
            visited.Add(current.val);

            if (createds.ContainsKey(current.val))
            {
                newNode = createds[current.val];
            }
            else
            {
                newNode = new Node(current.val);
                createds[current.val] = newNode;
            }

            foreach (var n in current.neighbors)
            {
                if (createds.ContainsKey(n.val))
                {
                    newNode.neighbors.Add(createds[n.val]);
                }
                else
                {
                    var newN = new Node(n.val);
                    createds[n.val] = newN;
                    newNode.neighbors.Add(newN);
                }
                if (!visited.Contains(n.val))
                {
                    visited.Add(n.val);
                    staco.Push(n);
                };
            }
        }

        return createds[1];
    }
}



public class GraphsClonnerRecursive : IGraphsClonner
{
    public Node? CloneGraph(Node? node)
    {
        return Clone(node);
    }

    private Node? Clone(Node? node, Dictionary<int, Node>? visitedNodes = null)
    {
        visitedNodes ??= [];

        if (node is null)
            return null;

        var nodeHead = new Node(node.val);
        visitedNodes.Add(node.val, nodeHead);

        foreach (var item in node.neighbors)
        {
            if (visitedNodes.ContainsKey(item.val))
            {
                nodeHead.neighbors.Add(visitedNodes[item.val]);
            }
            else
            {
                var clone = Clone(item, visitedNodes);
                if (clone is not null)
                    nodeHead.neighbors.Add(clone);
            }
        }

        return nodeHead;
    }
}

