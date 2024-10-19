
public interface IKthSmallestElementInBst
{
    public int KthSmallest(TreeNode root, int k);
}

public class KthSmallestElementInBstRecursive : IKthSmallestElementInBst
{
    //Basically do an In Order Depth First Search
    public int KthSmallest(TreeNode root, int k)
    {
        int response = -1;
        DfsInOrder(root, ref k, ref response);
        return response;
    }

    private void DfsInOrder(TreeNode root, ref int k, ref int response)
    {
        if (root.left is not null)
            DfsInOrder(root.left, ref k, ref response);

        if (k == 1)
        {
            response = root.val;
        }
        k--;

        if (k > 0 && root.right is not null)
            DfsInOrder(root.right, ref k, ref response);

    }
}


public class KthSmallestElementInBstIterative : IKthSmallestElementInBst
{
    //Basically do an In Order Depth First Search
    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var current = root;

        int count = 0;
        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            count++;
            if (count == k)
                return current.val;

            current = current.right;
        }

        return -1;
    }

}
