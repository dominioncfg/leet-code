namespace LeetCode.Tests;

/*
39. Combination Sum

Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. 
You may return the combinations in any order.
The same number may be chosen from candidates an unlimited number of times. 
Two combinations are unique if the frequency of at least one of the chosen numbers is different.
The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.


Example 1:
Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.

Example 2:
Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]

Example 3:
Input: candidates = [2], target = 1
Output: []

Constraints:

    1 <= candidates.length <= 30
    2 <= candidates[i] <= 40
    All elements of candidates are distinct.
    1 <= target <= 40
 */

public class CombinationSumTests
{
    private readonly ICombinationSumCalculator sut;
    public CombinationSumTests()
    {
        sut = new CombinationSumCalculator();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.CombinationSum([2, 3, 6, 7], 7);
        result.Should().HaveCount(2);

        result.Should().ContainEquivalentOf<int[]>([2, 2, 3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([7], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.CombinationSum([2, 3, 5], 8);
        result.Should().HaveCount(3);

        result.Should().ContainEquivalentOf<int[]>([2, 2, 2, 2], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2, 3, 3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([3, 5], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        var result = sut.CombinationSum([2], 1);
        result.Should().HaveCount(0);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.CombinationSum([8, 6, 17, 4, 21, 11, 31, 27, 14, 23, 28, 39], 32);
        result.Should().HaveCount(18);
    }
}