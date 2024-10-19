namespace LeetCode.Tests;

/*
230. Kth Smallest Element in a BST
Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

Example 1:
Input: root = [3,1,4,null,2], k = 1
Output: 1

Example 2:
Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3

Constraints:
    The number of nodes in the tree is n.
    1 <= k <= n <= 104
    0 <= Node.val <= 104
 */

public class KthSmallestElementInBstTest
{
    private readonly IKthSmallestElementInBst sut;
    public KthSmallestElementInBstTest()
    {
        sut = new KthSmallestElementInBstRecursive();
    }

    [Fact]
    public void Test1()
    {
        var t1 = TreeNode.FromEnumerable([3, 1, 4, null, 2]);
        var result = sut.KthSmallest(t1!, 1);
        result.Should().Be(1);
    }



    [Fact]
    public void Test2()
    {
        var t1 = TreeNode.FromEnumerable([5, 3, 6, 2, 4, null, null, 1]);
        var result = sut.KthSmallest(t1!, 3);
        result.Should().Be(3);
    }

    [Fact]
    public void Test3()
    {
        var t1 = TreeNode.FromEnumerable([5, 3, 6, 2, 4, null, null, 1]);
        var result = sut.KthSmallest(t1!, 6);
        result.Should().Be(6);
    }

    [Fact]
    public void Test4()
    {
        var t1 = TreeNode.FromEnumerable([5]);
        var result = sut.KthSmallest(t1!, 1);
        result.Should().Be(5);
    }
}