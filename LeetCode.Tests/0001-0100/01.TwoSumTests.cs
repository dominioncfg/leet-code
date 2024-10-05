
namespace LeetCode.Tests;

/*
 Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.



Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]



Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists. 
 */

public class TwoSumTests
{
    private readonly ITwoSumSolution sut;
    public TwoSumTests()
    {
        sut = new TwoSumLinearAsWeGoSolution();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.TwoSum([2, 7, 11, 15], 9);
        result.Should().BeEquivalentTo([0, 1], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.TwoSum([3, 2, 4], 6);
        result.Should().BeEquivalentTo([1, 2], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        var result = sut.TwoSum([3, 3], 6);
        result.Should().BeEquivalentTo([0, 1], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test4()
    {
        var result = sut.TwoSum([1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1], 11);
        result.Should().BeEquivalentTo([5, 11], options => options.WithStrictOrdering());
    }
}