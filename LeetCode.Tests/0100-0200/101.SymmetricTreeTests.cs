namespace LeetCode.Tests;

/*
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

Example 1:
Input: root = [1,2,2,3,4,4,3]
Output: true

Example 2:
Input: root = [1,2,2,null,3,null,3]
Output: false

Constraints:
    The number of nodes in the tree is in the range [1, 1000].
    -100 <= Node.val <= 100
 */

public class SymmetricTreeTests
{
    private readonly ISymmetricTree sut;
    public SymmetricTreeTests()
    {
        sut = new SymmetricTreeRecursive();
    }

    [Fact]
    public void Test1()
    {
        var t1 = new TreeNodeBuilder()
         .WithValue(1)
             .WithLeft(t => t
                .WithValue(2)
                    .WithLeft(3)
                    .WithRight(4)
             )

             .WithRight(t => t
                .WithValue(2)
                    .WithLeft(4)
                    .WithRight(3)
             )
         .Build();


        var result = sut.IsSymmetric(t1);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var t1 = new TreeNodeBuilder()
         .WithValue(1)
             .WithLeft(t => t
                .WithValue(2)
                    .WithRight(3)
             )

             .WithRight(t => t
                .WithValue(2)
                    .WithRight(3)
             )
         .Build();


        var result = sut.IsSymmetric(t1);
        result.Should().BeFalse();
    }
}