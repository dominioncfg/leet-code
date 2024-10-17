namespace LeetCode.Tests;

/*
110. Balanced Binary Tree

Given a binary tree, determine if it is height-balanced.

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: true

Example 2:
Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

Example 3:
Input: root = []
Output: true

Constraints:

    The number of nodes in the tree is in the range [0, 5000].
    -10^4 <= Node.val <= 10^4
 */

public class BalancedBinaryTreeTests

{
    private readonly IBalancedBinaryTree sut;
    public BalancedBinaryTreeTests()
    {
        sut = new BalancedBinaryTree();
    }

    [Fact]
    public void Test1()
    {
        var t1 = new TreeNodeBuilder()
         .WithValue(3)
             .WithLeft(9)
             .WithRight(l => l
                 .WithValue(20)
                     .WithLeft(15)
                     .WithRight(7)
              )
             .Build();
        var result = sut.IsBalanced(t1);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var t1 = new TreeNodeBuilder()
         .WithValue(1)
             .WithRight(2)
             .WithLeft(l => l
                 .WithValue(2)
                     .WithRight(3)
                     .WithLeft(l => l
                        .WithValue(3)
                        .WithLeft(4)
                        .WithRight(4)
                     )
              )
             .Build();
        var result = sut.IsBalanced(t1);
        result.Should().BeFalse();
    }
}