public interface IDiameterOfBinaryTreeCalculator
{
    public int DiameterOfBinaryTree(TreeNode root);
}

public class DiameterOfBinaryTreeCalculator : IDiameterOfBinaryTreeCalculator
{

    public int DiameterOfBinaryTree(TreeNode root)
    {
        var resultHolder = new DtoMaxFound() { Max = 0 };
        var diameter = DiameterNodeOfBinaryTree(root, resultHolder);

        return resultHolder.Max;
    }


    private (int Depth, int MaxDiameter) DiameterNodeOfBinaryTree(TreeNode? root, DtoMaxFound maxFound)
    {
        if (root is null)
            return (0, 0);

        var l = DiameterNodeOfBinaryTree(root.left, maxFound);
        var r = DiameterNodeOfBinaryTree(root.right, maxFound);

        var currentNodeDepth = Math.Max(l.Depth, r.Depth) + 1;
        var diameter = l.Depth + r.Depth;



        if(diameter>maxFound.Max)
        {
            maxFound.Max = diameter;
        }


        return (currentNodeDepth, diameter);
    }

    class DtoMaxFound
    {
        public int Max { get; set; }
    }
}

