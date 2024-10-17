namespace LeetCode.Tests;

public class TreeNodeBuilder
{
    private int val;
    private TreeNode? left;
    private TreeNode? right;


    public TreeNodeBuilder WithValue(int value)
    {
        val = value;
        return this;
    }

    private TreeNodeBuilder WithLeft(TreeNode value)
    {
        left = value;
        return this;
    }

    public TreeNodeBuilder WithLeft(Action<TreeNodeBuilder> value)
    {
        var builder = new TreeNodeBuilder();
        value(builder);

        return this.WithLeft(builder.Build());
    }
    public TreeNodeBuilder WithLeft(int value)
    {
        return WithLeft(l => l.WithValue(value));
    }

    private TreeNodeBuilder WithRight(TreeNode value)
    {
        right = value;
        return this;
    }

    public TreeNodeBuilder WithRight(Action<TreeNodeBuilder> value)
    {
        var builder = new TreeNodeBuilder();
        value(builder);
        return this.WithRight(builder.Build());
    }

    public TreeNodeBuilder WithRight(int value)
    {
        return WithRight(l => l.WithValue(value));
    }

    public TreeNode Build()
    {
        return new TreeNode(val, left, right);
    }
}
