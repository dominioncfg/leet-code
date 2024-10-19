public interface IValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root);
}

public class ValidateBinarySearchTreeRecursive : IValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBinarySearchTree(root);
    }

    public bool IsValidBinarySearchTree(TreeNode? root, int? min =  null, int? max = null)
    {
        if (root is null)
            return true;

        if (min.HasValue && root.val <= min)
            return false;

        if ( max.HasValue && root.val >= max)
            return false;


        if (!IsValidBinarySearchTree(root.left, min, root.val))
            return false;

        return IsValidBinarySearchTree(root.right, root.val, max);
    }
}


public class ValidateBinarySearchTreeRecursivePreOrdenPointingToMin : IValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {
        var isValidSoFar = true;
        var previous = (int?)null;
        IsValidBinarySearchTree(root, ref previous, ref isValidSoFar);
        return isValidSoFar;
    }

    public void IsValidBinarySearchTree(TreeNode root, ref int? previous, ref bool isValidSoFar)
    {
        if (root.left is not null)
            IsValidBinarySearchTree(root.left, ref previous, ref isValidSoFar);


        if (previous.HasValue && root.val <= previous.Value)
        {
            isValidSoFar = false;
        }

        previous = root.val;

        if (isValidSoFar && root.right is not null)
            IsValidBinarySearchTree(root.right, ref previous, ref isValidSoFar);
    }
}


public class ValidateBinarySearchTreeIterative : IValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {

        var stackForPreorderIteration = new Stack<TreeNode>();
        var current = root;
        int? previous = null;
        while (stackForPreorderIteration.Count > 0 || current is not null)
        {
            while (current is not null)
            {
                stackForPreorderIteration.Push(current);
                current = current.left;
            }
            //Current Element
            current = stackForPreorderIteration.Pop();


            if (previous.HasValue && current.val <= previous.Value)
            {
                return false;
            }

            previous = current.val;
            //Proccess the right
            current = current.right;
        }


        return true;
    }
}
