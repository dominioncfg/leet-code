namespace LeetCode.Tests;

/*
572. Subtree of Another Tree

Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.
A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.

Example 1:
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true

Example 2:
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false

Constraints:
    The number of nodes in the root tree is in the range [1, 2000].
    The number of nodes in the subRoot tree is in the range [1, 1000].
    -10^4 <= root.val <= 10^4
    -10^4 <= subRoot.val <= 10^4
 */

public class SubtreeOfAnotherTreeTests
{
    private readonly ISubtreeOfAnotherTree sut;
    public SubtreeOfAnotherTreeTests()
    {
        sut = new SubtreeOfAnotherTreeRecursive();
    }

    [Fact]
    public void Test1()
    {
        var subTree = new TreeNodeBuilder()
              .WithValue(4)
                  .WithLeft(1)
                  .WithRight(2)
             .Build();

        var tree = new TreeNodeBuilder()
               .WithValue(3)
               .WithRight(5)
               .WithLeft(l => l
                   .WithValue(4)
                       .WithLeft(1)
                       .WithRight(2)
               )
               .Build();
        var result = sut.IsSubtree(tree, subTree);
        result.Should().BeTrue();
    }


    [Fact]
    public void Test2()
    {
        var subTree = new TreeNodeBuilder()
             .WithValue(4)
                 .WithLeft(1)
                 .WithRight(2)
            .Build();

        var tree = new TreeNodeBuilder()
               .WithValue(3)
               .WithRight(5)
               .WithLeft(l => l
                   .WithValue(4)
                       .WithLeft(1)
                       .WithRight(t => t
                        .WithValue(2)
                        .WithLeft(0))
               )
               .Build();
        var result = sut.IsSubtree(tree, subTree);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var subTree = new TreeNodeBuilder()
              .WithValue(4)
                  .WithLeft(l => l
                  .WithValue(1)
                  .WithRight(2))
             .Build();

        var tree = new TreeNodeBuilder()
               .WithValue(3)
               .WithRight(5)
               .WithLeft(l => l
                   .WithValue(4)
                       .WithLeft(1)
                       .WithRight(2)
               )
               .Build();
        var result = sut.IsSubtree(tree, subTree);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test4()
    {
        var subTree = new TreeNodeBuilder()
              .WithValue(4)
                  .WithRight(2)
                  .WithLeft(l => l
                    .WithValue(1)
                    .WithLeft(1)
                  )
             .Build();

        var tree = new TreeNodeBuilder()
               .WithValue(3)
               .WithRight(5)
               .WithLeft(l => l
                   .WithValue(4)
                       .WithLeft(1)
                       .WithRight(2)
               )
               .Build();
        var result = sut.IsSubtree(tree, subTree);
        result.Should().BeFalse();
    }

}