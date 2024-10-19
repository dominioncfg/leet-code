
using System.Diagnostics;

[DebuggerDisplay("Value = {val}")]
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }


    public override bool Equals(object? obj)
    {
        if (obj is not TreeNode ln)
            return base.Equals(obj);

        var thisNodeEnumerable = new List<int>();
        var otherNodeEnumerable = new List<int>();

        thisNodeEnumerable.AddRange(EnumaratePreOrdenTree(this));
        otherNodeEnumerable.AddRange(EnumaratePreOrdenTree(ln));

        if (thisNodeEnumerable.Count != otherNodeEnumerable.Count)
            return false;

        for (int i = 0; i < thisNodeEnumerable.Count; i++)
        {
            var item1 = thisNodeEnumerable[i];
            var item2 = otherNodeEnumerable[i];

            if (item1 != item2)
                return false;
        }

        return true;
    }

    private IEnumerable<int> EnumaratePreOrdenTree(TreeNode? treeNode)
    {
        List<int> result = new List<int>();

        var queue = new Queue<TreeNode>();

        if (treeNode is not null)
            queue.Enqueue(treeNode);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current.val);

            if (current.left is not null)
                queue.Enqueue(current.left);

            if (current.right is not null)
                queue.Enqueue(current.right);
        }

        return result;
    }

    public static TreeNode? FromEnumerable(int?[]? definition)
    {
        if (definition is null || definition.Length == 0 || definition[0] is null)
            return null;


        var queue = new Queue<TreeNode>();
        
        var root = new TreeNode(definition[0]!.Value);
        var current = root;
        queue.Enqueue(root);
        var i = 1;
        while (queue.Count > 0 && i < definition.Length)
        {
           var toNode = queue.Dequeue();

            if (definition[i].HasValue)
            {
                var nodeLeft = new TreeNode(definition[i]!.Value);
                toNode.left = nodeLeft;
                queue.Enqueue(nodeLeft);
            }

            if(i+1< definition.Length && definition[i+1].HasValue)
            {
                var nodeRight = new TreeNode(definition[i +1]!.Value);
                toNode.right = nodeRight;
                queue.Enqueue(nodeRight);
            }

            i += 2;
        }

        return root;
    }
}

