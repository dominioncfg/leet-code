namespace LeetCode.Tests;

/*
77. Combinations

Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].
You may return the answer in any order.

Example 1:
Input: n = 4, k = 2
Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
Explanation: There are 4 choose 2 = 6 total combinations.
Note that combinations are unordered, i.e., [1,2] and [2,1] are considered to be the same combination.

Example 2:
Input: n = 1, k = 1
Output: [[1]]
Explanation: There is 1 choose 1 = 1 total combination.

Constraints:
    1 <= n <= 20
    1 <= k <= n
 */

public class CombinationsTests

{
    private readonly ICombinations sut;
    public CombinationsTests()
    {
        sut = new CombinationsIterative();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.Combine(4, 2);
        result.Should().HaveCount(6);
        result.Should().ContainEquivalentOf<int[]>([1, 2], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1, 3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([1, 4], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2, 3], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([2, 4], options => options.WithoutStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([3, 4], options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.Combine(1,1);
        result.Should().HaveCount(1);
        result.Should().ContainEquivalentOf<int[]>([1], options => options.WithoutStrictOrdering());
    }  
}