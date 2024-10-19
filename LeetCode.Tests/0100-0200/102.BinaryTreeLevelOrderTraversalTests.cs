namespace LeetCode.Tests;

/*
102. Binary Tree Level Order Traversal

Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
 

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]

Example 2:
Input: root = [1]
Output: [[1]]

Example 3:
Input: root = []
Output: []

Constraints:
    The number of nodes in the tree is in the range [0, 2000].
    -1000 <= Node.val <= 1000
 */


public class BinaryTreeLevelOrderTraversalTests
{
    private readonly IBinaryTreeLevelOrderTraversal sut;
    public BinaryTreeLevelOrderTraversalTests()
    {
        sut = new BinaryTreeLevelOrderTraversal();
    }

    [Fact]
    public void Test1()
    {
        var tree = TreeNode.FromEnumerable([3, 9, 20, null, null, 15, 7]);
        var result = sut.LevelOrder(tree);

        result.Should().NotBeNull().And.HaveCount(3);

        result[0].Should().BeEquivalentTo([3], options => options.WithStrictOrdering());
        result[1].Should().BeEquivalentTo([9,20], options => options.WithStrictOrdering());
        result[2].Should().BeEquivalentTo([15, 7], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var tree = TreeNode.FromEnumerable([1]);
        var result = sut.LevelOrder(tree);

        result.Should().NotBeNull().And.HaveCount(1);

        result[0].Should().BeEquivalentTo([1], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        var tree = TreeNode.FromEnumerable([]);
        var result = sut.LevelOrder(null);
        result.Should().NotBeNull().And.HaveCount(0);
    }

}