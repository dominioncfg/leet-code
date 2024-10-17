
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

