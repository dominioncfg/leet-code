public interface IMinimumAbsoluteDifferenceInBst
{
    public int GetMinimumDifference(TreeNode root);
}

public class MinimumAbsoluteDifferenceInBstRecursive : IMinimumAbsoluteDifferenceInBst
{

    public int GetMinimumDifference(TreeNode root)
    {
        int response = int.MaxValue;
        TreeNode tnode = null;
        
        DfsInOrder(root, ref tnode, ref response);
        return response;
    }

    //Basically do an In Order Depth First Search
    private void DfsInOrder(TreeNode root, ref TreeNode? previous, ref int minDiff )
    {
        if (root.left is not null)
            DfsInOrder(root.left, ref previous, ref minDiff);

        if (previous is not null)
        {
            var diff = Math.Abs(root.val - previous.val);
            if (minDiff > diff)
                minDiff = diff;
        }

        previous = root;


        if (minDiff>1 &&  root.right is not null)
            DfsInOrder(root.right, ref previous, ref minDiff);

    }
}


public class MinimumAbsoluteDifferenceInBstIterative : IMinimumAbsoluteDifferenceInBst
{

    public int GetMinimumDifference(TreeNode root)
    {    
        var minDifference = int.MaxValue;

        var stack = new Stack<TreeNode>();
        var current = root;
        TreeNode? previous = null;

        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

          
            current = stack.Pop();
           
            if(previous is not null)
            {
                var diff =  Math.Abs(current.val - previous.val);
                if(minDifference > diff)
                    minDifference = diff;

                if (minDifference <= 1)
                    return minDifference;
            }

            previous = current;
            current = current.right;
        }
        return minDifference;
    }
}

