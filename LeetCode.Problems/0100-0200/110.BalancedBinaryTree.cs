public interface IBalancedBinaryTree
{
    public bool IsBalanced(TreeNode root);
}

public class BalancedBinaryTree : IBalancedBinaryTree
{
    public bool IsBalanced(TreeNode root)
    {
        if (root is null || (root.left is null && root.right is null))
            return true;

        return MaxDepth(root).IsBalanced;
    }
    public (int Depth, bool IsBalanced) MaxDepth(TreeNode? root)
    {
        if (root is null)
            return (0, true);

        var l = MaxDepth(root.left);
        var r = MaxDepth(root.right);

        if(!l.IsBalanced||!r.IsBalanced)
            return(0, false);

        var isBalanced = Math.Abs(l.Depth - r.Depth) <= 1;
        return (Math.Max(l.Depth, r.Depth) + 1, isBalanced);
    }


}