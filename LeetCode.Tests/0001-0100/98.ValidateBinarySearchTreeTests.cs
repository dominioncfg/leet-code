namespace LeetCode.Tests;

/*
98. Validate Binary Search Tree
Given the root of a binary tree, determine if it is a valid binary search tree (BST).
A valid BST is defined as follows:
   - The left subtree  of a node contains only nodes with keys less than the node's key.
   - The right subtree of a node contains only nodes with keys greater than the node's key.
   - Both the left and right subtrees must also be binary search trees.

Example 1:
Input: root = [2,1,3]
Output: true

Example 2:
Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.

Constraints:
    The number of nodes in the tree is in the range [1, 104].
    -231 <= Node.val <= 231 - 1
 */

public class ValidateBinarySearchTreeTests
{
    private readonly IValidateBinarySearchTree sut;
    public ValidateBinarySearchTreeTests()
    {
        sut = new ValidateBinarySearchTreeRecursive();
    }

    [Fact]
    public void Test1()
    {
        var tree = TreeNode.FromEnumerable([2, 1, 3]);
        var result = sut.IsValidBST(tree!);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var tree = TreeNode.FromEnumerable([5, 1, 4, null, null, 3, 6]);
        var result = sut.IsValidBST(tree!);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var tree = TreeNode.FromEnumerable([5, 4, 6, null, null, 3, 7]);
        var result = sut.IsValidBST(tree!);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test4()
    {
        var tree = TreeNode.FromEnumerable([2147483647]);
        var result = sut.IsValidBST(tree!);
        result.Should().BeTrue();
    }


    [Fact]
    public void Test5()
    {
        var tree = TreeNode.FromEnumerable([1, null, 1]);
        var result = sut.IsValidBST(tree!);
        result.Should().BeFalse();
    }


}