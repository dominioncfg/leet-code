﻿namespace LeetCode.Tests;

/*
226. Invert Binary Tree
Given the root of a binary tree, invert the tree, and return its root.

Example 1:
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:
Input: root = [2,1,3]
Output: [2,3,1]

Example 3:
Input: root = []
Output: []

Constraints:
    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100
 */

public class InvertBinaryTreeTests
{
    private readonly IInvertBinaryTree sut;
    public InvertBinaryTreeTests()
    {
        sut = new InvertBinaryTreeQueueSolution();
    }

    [Fact]
    public void Test1()
    {
        var t1 = new TreeNodeBuilder()
            .WithValue(4)
                .WithLeft(l => l
                    .WithValue(2)
                        .WithLeft(1)
                        .WithRight(3)
                )
                .WithRight(l => l
                    .WithValue(7)
                        .WithLeft(6)
                        .WithRight(9)
                 )
                .Build();

        var expected = new TreeNodeBuilder()
            .WithValue(4)
                .WithLeft(l => l
                    .WithValue(7)
                        .WithLeft(9)
                        .WithRight(6)
                )
                .WithRight(l => l
                    .WithValue(2)
                        .WithLeft(3)
                        .WithRight(1)
                 )
                .Build();


        var result = sut.InvertTree(t1);
        result.Should().Be(expected);
    }


    [Fact]
    public void Test2()
    {
        var t1 = new TreeNodeBuilder()
            .WithValue(2)
                .WithLeft(1)
                .WithRight(3)
             .Build();

        var expected = new TreeNodeBuilder()
             .WithValue(2)
                .WithLeft(3)
                .WithRight(1)
             .Build(); ;


        var result = sut.InvertTree(t1);
        result.Should().Be(expected);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.InvertTree(null);
        result.Should().Be(null);
    }
}
