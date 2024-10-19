
public interface ISubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot);
}


public class SubtreeOfAnotherTreeRecursive : ISubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return HasSameSubtree(root, subRoot);
    }

    public bool HasSameSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root is null)
            return false;

        if (IsSameTree(root, subRoot))
            return true;


        return HasSameSubtree(root?.left, subRoot) || HasSameSubtree(root?.right, subRoot);
    }


    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
            return true;

        if (p is null || q is null)
            return false;

        if (p.val != q.val)
            return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}



public class SubtreeOfAnotherTreeQueues : ISubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        var generalNodesQueues = new Queue<TreeNode>();
        generalNodesQueues.Enqueue(root);


        while (generalNodesQueues.Count > 0)
        {
            var node = generalNodesQueues.Dequeue();

            if (node.val == subRoot.val)
            {
                var rootNodeCheckQueue = new Queue<TreeNode>();
                var subrootNodeCheckQueue = new Queue<TreeNode>();

                var rootNode = node;
                var subrootNode = subRoot;

                bool allEquals = true;

                rootNodeCheckQueue.Enqueue(rootNode);
                subrootNodeCheckQueue.Enqueue(subrootNode);
                while (rootNodeCheckQueue.Count > 0 && subrootNodeCheckQueue.Count > 0)
                {
                    var checkNode = rootNodeCheckQueue.Dequeue();
                    var subTreeCheckNode = subrootNodeCheckQueue.Dequeue();

                    if (checkNode.val != subTreeCheckNode.val)
                    {
                        allEquals = false;
                        break;
                    }

                    if (checkNode.left is not null && subTreeCheckNode.left is not null)
                    {
                        rootNodeCheckQueue.Enqueue(checkNode.left);
                        subrootNodeCheckQueue.Enqueue(subTreeCheckNode.left);
                    }
                    else if (checkNode.left is not null || subTreeCheckNode.left is not null)
                    {
                        allEquals = false;
                        break;
                    }


                    if (checkNode.right is not null && subTreeCheckNode.right is not null)
                    {
                        rootNodeCheckQueue.Enqueue(checkNode.right);
                        subrootNodeCheckQueue.Enqueue(subTreeCheckNode.right);
                    }
                    else if (checkNode.right is not null || subTreeCheckNode.right is not null)
                    {
                        allEquals = false;
                        break;
                    }

                }

                if (allEquals && rootNodeCheckQueue.Count == 0 && subrootNodeCheckQueue.Count == 0)
                    return true;
            }


            if (node.left is not null)
                generalNodesQueues.Enqueue(node.left);

            if (node.right is not null)
                generalNodesQueues.Enqueue(node.right);
        }



        return false;
    }
}

