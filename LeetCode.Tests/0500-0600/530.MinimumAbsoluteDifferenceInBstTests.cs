namespace LeetCode.Tests;

/*
530. Minimum Absolute Difference in BST
Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.

Example 1:
Input: root = [4,2,6,1,3]
Output: 1

Example 2:
Input: root = [1,0,48,null,null,12,49]
Output: 1

Constraints:
    The number of nodes in the tree is in the range [2, 104].
    0 <= Node.val <= 105
 */

public class MinimumAbsoluteDifferenceInBstTests
{
    private readonly IMinimumAbsoluteDifferenceInBst sut;
    public MinimumAbsoluteDifferenceInBstTests()
    {
        sut = new MinimumAbsoluteDifferenceInBstRecursive();
    }

    [Fact]
    public void Test1()
    {
        var tree = TreeNode.FromEnumerable([4, 2, 6, 1, 3]);
        var result = sut.GetMinimumDifference(tree!);
        result.Should().Be(1);
    }


    [Fact]
    public void Test2()
    {
        var tree = TreeNode.FromEnumerable([1, 0, 48, null, null, 12, 49]);
        var result = sut.GetMinimumDifference(tree!);
        result.Should().Be(1);
    }

    [Fact]
    public void Test3()
    {
        var tree = TreeNode.FromEnumerable([236, 104, 701, null, 227, null, 911]);
        var result = sut.GetMinimumDifference(tree!);
        result.Should().Be(9);
    }

}