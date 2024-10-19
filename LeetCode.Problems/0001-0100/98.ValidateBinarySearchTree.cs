public interface IValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root);
}

public class ValidateBinarySearchTreeRecursive : IValidateBinarySearchTree
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
