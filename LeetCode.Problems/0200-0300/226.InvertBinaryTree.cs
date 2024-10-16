
public interface IInvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root);
}

public class InvertBinaryTreeQueueSolution : IInvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
            return root;


        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            
            if (current is null)
                continue;

            queue.Enqueue(current.left);
            queue.Enqueue(current.right);


            var tmp = current.left;
            current.left = current.right;
            current.right = tmp;
        }


        return root;
    }
}

public class InvertBinaryTreeRecursiveSolution : IInvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null || (root.left is null && root.right is null))
            return root;

        var right = InvertTree(root.right);
        var left = InvertTree(root.left);

        root.left = right;
        root.right = left;
        return root;
    }
}



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
}

