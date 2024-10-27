namespace LeetCode.Tests;

/*
46. Permutations

Given an array nums of distinct integers, return all the possible
permutations
You can return the answer in any order.

 

Example 1:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:
Input: nums = [0,1]
Output: [[0,1],[1,0]]

Example 3:
Input: nums = [1]
Output: [[1]]

Constraints:
    1 <= nums.length <= 6
    -10 <= nums[i] <= 10
    All the integers of nums are unique.
 */

public class PermutationsTests
{
    private readonly IPermutations sut;
    public PermutationsTests()
    {
        sut = new PermutationsRecursive();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.Permute([1, 2, 3]);
        result.Should().HaveCount(6);

        result.Should().ContainEquivalentOf<int[]>([1, 2, 3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1, 3, 2], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2, 1, 3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2, 3, 1], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([3, 1, 2], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([3, 2, 1], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.Permute([0, 1]);
        result.Should().HaveCount(2);

        result.Should().ContainEquivalentOf<int[]>([0, 1], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1, 0], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        var result = sut.Permute([1]);
        result.Should().HaveCount(1);

        result.Should().ContainEquivalentOf<int[]>([1], options => options.WithoutStrictOrdering());
    }
}