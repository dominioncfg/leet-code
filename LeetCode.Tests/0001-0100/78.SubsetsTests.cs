namespace LeetCode.Tests;

/*
78. Subsets

Given an integer array nums of unique elements, return all possible
subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:
Input: nums = [0]
Output: [[],[0]]

 

Constraints:
    1 <= nums.length <= 10
    -10 <= nums[i] <= 10
    All the numbers of nums are unique.
 */

public class SubsetsTests
{
    private readonly IAllSubsets sut;
    public SubsetsTests()
    {
        sut = new AllSubsetsIterative();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.Subsets([1, 2, 3]);
        result.Should().HaveCount(8);

        result.Should().ContainEquivalentOf<int[]>([], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1,2], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1,3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2,3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1,2,3], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.Subsets([0]);
        result.Should().HaveCount(2);

        result.Should().ContainEquivalentOf<int[]>([], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([0], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        var result = sut.Subsets([]);
        result.Should().HaveCount(1);

        result.Should().ContainEquivalentOf<int[]>([], options => options.WithoutStrictOrdering());
    }
}