public interface ISameTree
{
    public bool IsSameTree(TreeNode p, TreeNode q);
}

public class SameTree : ISameTree
{
    public bool IsSameTree(TreeNode p, TreeNode q)
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


            qQ.Enqueue(currentQ.left);
            qQ.Enqueue(currentQ.right);

        }


        return pQ.Count == 0 && qQ.Count == 0;
    }
}