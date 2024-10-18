public interface IBinaryTreePathSum
{
    public bool HasPathSum(TreeNode? root, int targetSum);
}

public class BinaryTreePathSumRecursive : IBinaryTreePathSum
{
    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root is null)
            return false;

        if(root.left is null && root.right is null)
        {
            return root.val == targetSum;
        }

        var isThereALeftPath = HasPathSum(root.left, targetSum - root.val);
        
        if (isThereALeftPath)
            return true;

        var isThereARightPath = HasPathSum(root.right, targetSum - root.val);
        return isThereARightPath;
    }
}

public class BinaryTreePathSumIterative : IBinaryTreePathSum
{
    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        var toVisit = new Stack<TreeNode?>();
        var visited = new Stack<TreeNode>();

        if (root is null)
            return false;

        var sumSoFar = root.val;
        toVisit.Push(root);
        while (toVisit.Count > 0)
        {
            var current = toVisit.Peek()!;

            if (current.left is not null && !visited.Contains(current.left))
            {
                var left = current.left;
                while (left is not null && !visited.Contains(left))
                {
                    toVisit.Push(left);
                    sumSoFar += left.val;
                    left = left.left;

                }
            }
            else if (current.right is not null && !visited.Contains(current.right))
            {
                var right = current.right;
                while (right is not null)
                {
                    toVisit.Push(right);
                    sumSoFar += right.val;
                    right = right.right;
                }
            }
            else
            {
                toVisit.Pop();
                if (sumSoFar == targetSum && current.left is null && current.right is null)
                    return true;
                sumSoFar -= current.val;
                visited.Push(current);
            }
        }


        return false;
    }
}