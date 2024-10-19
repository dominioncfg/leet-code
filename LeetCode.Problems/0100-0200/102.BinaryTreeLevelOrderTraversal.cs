public interface IBinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode? root);
}

public class BinaryTreeLevelOrderTraversal : IBinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        var response = new List<IList<int>>();

        if (root is null)
            return  new List<IList<int>>();


        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var queueLength = queue.Count;
            var level = new List<int>(queueLength);
            

            for (int i = 1; i <= queueLength; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);

                if (node.left is not null)
                    queue.Enqueue(node.left);

                if (node.right is not null)
                    queue.Enqueue(node.right);
            }
            response.Add(level);
            
        }

        return response;
    }

    public void LevelOrder(TreeNode? root, int currentDepth, List<IList<int>> response)
    {
      


    }
}


public class BinaryTreeLevelOrderRecursive : IBinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        var response = new List<IList<int>>();

        LevelOrder(root, 0, response);

        return response;
    }

    public void LevelOrder(TreeNode? root, int currentDepth, List<IList<int>> response)
    {
        if (root is null)
            return;

        IList<int>? addToList = null;
        if(response.Count== currentDepth)
        {
            addToList = new List<int>();
            response.Add(addToList);
        }
        else
        {
            addToList = response[currentDepth];
        }

        addToList.Add(root.val);

        if (root.left is not null)
            LevelOrder(root.left, currentDepth + 1, response);

        if (root.right is not null)
            LevelOrder(root.right, currentDepth + 1, response);

    }
}
