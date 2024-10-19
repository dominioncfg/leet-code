
public interface ILowestCommonAncestorOfABinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q);
}

public class LowestCommonAncestorOfABinarySearchTreeIterative : ILowestCommonAncestorOfABinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var currentNode = root;
        while (currentNode is not null)
        {
            if (currentNode.val == p.val)
                return p;

            if (currentNode.val == q.val)
                return q;


            var minVal = Math.Min(p.val, q.val);
            var maxVal = Math.Max(p.val, q.val);
            if (minVal < currentNode.val && currentNode.val < maxVal)
                return currentNode;


            if (minVal < currentNode.val)
                currentNode = currentNode.left;
            else 
                currentNode = currentNode.right;
        }

        throw new Exception("Could not find a solution according to the A/C");
    }
}


public class LowestCommonAncestorOfABinarySearchTreeRecursive : ILowestCommonAncestorOfABinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val == p.val)
            return p;

        if(root.val == q.val)
            return q;

        var minVal = Math.Min(p.val, q.val);
        var maxVal = Math.Max(p.val, q.val);

        if (minVal < root.val && root.val < maxVal)
            return root;

        if (minVal < root.val)
            return LowestCommonAncestor(root.left,p,q);



        return LowestCommonAncestor(root.right, p, q); ;
    }
}
