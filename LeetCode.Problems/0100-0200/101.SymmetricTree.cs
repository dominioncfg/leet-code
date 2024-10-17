public interface ISymmetricTree
{
    public bool IsSymmetric(TreeNode root);
}

public class SymmetricTreeRecursive : ISymmetricTree
{
    public bool IsSymmetric(TreeNode root)
    {
        return AreMirrorTrees(root.left, root.right);
    }

    private bool AreMirrorTrees(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
            return true;

        if (p is null || q is null)
            return false;


        if(p.val != q.val)
            return false;

        if (!AreMirrorTrees(p.left, q.right))
            return false;

        if (!AreMirrorTrees(p.right, q.left))
            return false;

        return true; 
    }
}

public class SymmetricTreeIterative : ISymmetricTree
{
    public bool IsSymmetric(TreeNode root)
    {
        return AreMirrorTrees(root.left, root.right);
    }

    private bool AreMirrorTrees(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
            return true;

        var pQ = new Queue<TreeNode>();
        var qQ = new Queue<TreeNode>();

        pQ.Enqueue(p);
        qQ.Enqueue(q);

        while (pQ.Count > 0)
        {
            if (qQ.Count == 0)
                return false;

            var currentP = pQ.Dequeue();
            var currentQ = qQ.Dequeue();

            if (currentP is null && currentQ is null)
                continue;

            if (currentP is null || currentQ is null)
                return false;

            if (currentP?.val != currentQ?.val)
                return false;

            pQ.Enqueue(currentP.left);
            pQ.Enqueue(currentP.right);


            qQ.Enqueue(currentQ.right);
            qQ.Enqueue(currentQ.left);

        }


        return pQ.Count == 0 && qQ.Count == 0;
    }
}