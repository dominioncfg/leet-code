namespace LeetCode.Tests;

public class NodeFromEnumerableTests
{

    [Fact]
    public void EmptyReturnsNoTree()
    {
        var treeNode = TreeNode.FromEnumerable([null]);
        treeNode.Should().BeNull();
    }

    [Fact]
    public void NullReturnsNoTree()
    {
        var treeNode = TreeNode.FromEnumerable([]);
        treeNode.Should().BeNull();
    }

    [Fact]
    public void NullEntireObjectReturnsNoTree()
    {
        var treeNode = TreeNode.FromEnumerable(null);
        treeNode.Should().BeNull();
    }


    [Fact]
    public void SingleNodeIsReturned()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2]);
        treeNode.Should().Be(expected);
    }


    [Fact]
    public void NodeWithOnlyLeftIsReturned()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(3)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3]);
        treeNode.Should().Be(expected);
    }

    [Fact]
    public void NodeWithOnlyRightIsReturned()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithRight(3)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, null, 3]);
        treeNode.Should().Be(expected);
    }


    [Fact]
    public void NodeWithLeftAndRightIsReturned()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(3)
            .WithRight(4)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4]);
        treeNode.Should().Be(expected);
    }

    [Fact]
    public void ThreeLevelsSingleNodeFirstSpot()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(t => t
                .WithValue(3)
                .WithLeft(5))
            .WithRight(4)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, 5]);
        treeNode.Should().Be(expected);
    }

    [Fact]
    public void ThreeLevelsSingleNodeSecondSpot()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(t => t
                .WithValue(3)
                .WithRight(5))
            .WithRight(4)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, null, 5]);
        treeNode.Should().Be(expected);
    }


    [Fact]
    public void ThreeLevelsSingleNodeThirdSpot()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(3)
            .WithRight(t => t
                .WithValue(4)
                .WithLeft(5))
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, null, null, 5]);
        treeNode.Should().Be(expected);
    }

    [Fact]
    public void ThreeLevelsSingleNodeFourthSpot()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(3)
            .WithRight(t => t
                .WithValue(4)
                .WithRight(5))
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, null, null, null, 5]);
        treeNode.Should().Be(expected);
    }


    [Fact]
    public void ThreeLevelsLeftTreeFull()
    {
        var expected = new TreeNodeBuilder()
            .WithValue(2)
            .WithLeft(t => t
                .WithValue(3)
                .WithLeft(5)
                .WithRight(6)
            )
            .WithRight(4)
            .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, 5, 6]);
        treeNode.Should().Be(expected);
    }

    [Fact]
    public void ThreeLevelsLeftRightTreeFull()
    {
        var expected = new TreeNodeBuilder()
               .WithValue(2)
               .WithLeft(3)
               .WithRight(t => t
                   .WithValue(4)
                   .WithLeft(5)
                   .WithRight(6))
               .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, null, null, 5, 6]);
    }

    [Fact]
    public void ThreeLevelsFullThree()
    {
        var expected = new TreeNodeBuilder()
               .WithValue(2)
               .WithLeft(t => t
                .WithValue(3)
                .WithLeft(5)
                .WithRight(6)
              )
               .WithRight(t => t
                   .WithValue(4)
                   .WithLeft(7)
                   .WithRight(7)
                )
               .Build();
        var treeNode = TreeNode.FromEnumerable([2, 3, 4, 5, 6, 7, 8]);
    }
}
